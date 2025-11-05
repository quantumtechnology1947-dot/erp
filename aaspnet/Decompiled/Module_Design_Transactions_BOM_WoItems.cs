using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Design_Transactions_BOM_WoItems : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string wono = "";

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string SId = "";

	private int parentid;

	private int childid;

	private string AsslyNo = "";

	private string EquipNo = "";

	protected Label lblwono;

	protected Label lblasslyno;

	protected DropDownList DrpType;

	protected RequiredFieldValidator ReqSelect;

	protected DropDownList DrpCategory1;

	protected DropDownList DrpSearchCode;

	protected DropDownList DropDownList3;

	protected TextBox txtSearchItemCode;

	protected Button btnSearch;

	protected GridView GridView2;

	protected Panel Panel2;

	protected TabPanel TabPanel1;

	protected Label lblEquipNo;

	protected TextBox txtUnitNo;

	protected RequiredFieldValidator ReqUnitNo;

	protected TextBox txtPartNo;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox txtManfDescription;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected GridView GridView1;

	protected DropDownList DDLUnitBasic;

	protected RequiredFieldValidator RequiredFieldValidator6;

	protected TextBox txtQuntity;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegQty0;

	protected FileUpload FileUpload1;

	protected FileUpload FileUpload2;

	protected Button btnSubmit;

	protected Button Button1;

	protected Label lblMsg1;

	protected Label lblMsg;

	protected Panel Panel3;

	protected TabPanel TabPanel2;

	protected HtmlGenericControl frm2;

	protected TabPanel TabPanel3;

	protected GridView GridView3;

	protected Panel Panel1;

	protected TabPanel TabPanel4;

	protected TabContainer TabContainer1;

	protected Button btnaddtobom;

	protected Button Button2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	public void CreateNextUnitPartNo()
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			string text = lblasslyno.Text;
			string[] array = text.Split('-');
			string text2 = array[0] + "-" + array[1];
			txtUnitNo.Text = array[1];
			EquipNo = array[0];
			lblEquipNo.Text = EquipNo;
			txtPartNo.Text = (Convert.ToInt32(array[2]) + 1).ToString("D2");
			string cmdText = fun.select("PartNo", "tblDG_BOM_Master", "CompId='" + CompId + "' And PartNo is not null AND FinYearId<='" + FinYearId + "' And  PartNo like '" + text2 + "%' order by PartNo desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			int num = 0;
			string text3 = "";
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				string text4 = dataSet.Tables[0].Rows[0]["PartNo"].ToString();
				string[] array2 = text4.Split('-');
				num = Convert.ToInt32(array2[2]) + 1;
				text3 = num.ToString("D2");
			}
			string cmdText2 = fun.select("PartNo", "tblDG_BOMItem_Temp", "CompId='" + CompId + "' And PartNo is not null AND PartNo like '" + text2 + "%' order by PartNo desc");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			int num2 = 0;
			string text5 = "";
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				string text6 = dataSet2.Tables[0].Rows[0]["PartNo"].ToString();
				string[] array3 = text6.Split('-');
				num2 = Convert.ToInt32(array3[2]) + 1;
				text5 = num2.ToString("D2");
			}
			if (num > num2)
			{
				txtPartNo.Text = text3;
			}
			else
			{
				txtPartNo.Text = text5;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Page_Init(object sender, EventArgs e)
	{
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		con.Open();
		try
		{
			lblMsg.Text = "";
			lblMsg1.Text = "";
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			wono = base.Request.QueryString["WONo"].ToString();
			AsslyNo = base.Request.QueryString["ItemId"];
			parentid = Convert.ToInt32(base.Request.QueryString["PId"]);
			childid = Convert.ToInt32(base.Request.QueryString["CId"]);
			lblwono.Text = wono.ToString();
			lblasslyno.Text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(AsslyNo));
			if (!base.IsPostBack)
			{
				DrpCategory1.Items.Clear();
				DrpCategory1.Items.Insert(0, "Select");
				DropDownList3.Visible = false;
				DrpCategory1.Visible = false;
				DrpSearchCode.Visible = false;
				txtSearchItemCode.Visible = false;
				fun.drpunit(DDLUnitBasic);
				string selectedValue = DrpCategory1.SelectedValue;
				string selectedValue2 = DrpSearchCode.SelectedValue;
				string text = txtSearchItemCode.Text;
				string selectedValue3 = DrpType.SelectedValue;
				Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
			}
			CreateNextUnitPartNo();
			frm2.Attributes["src"] = "BOM_Design_CopyWo.aspx?WONoDest=" + wono + "&DestPId=" + parentid + "&DestCId=" + childid;
			FillDataGrid();
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
		string connectionString = fun.Connection();
		SqlConnection selectConnection = new SqlConnection(connectionString);
		new DataTable();
		try
		{
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			if (!(DrpType.SelectedValue != "Select"))
			{
				return;
			}
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
		catch (Exception)
		{
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			loaddata();
		}
		string cmdText = fun.select(" TaskDesignFinalization_TDate", " SD_Cust_WorkOrder_Master", "WONo='" + wono + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, con);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		string value = dataSet.Tables[0].Rows[0][0].ToString();
		string currDate = fun.getCurrDate();
		if (Convert.ToDateTime(value) >= Convert.ToDateTime(currDate))
		{
			GridView1.Visible = false;
		}
		else
		{
			GridView1.Visible = true;
		}
	}

	public void loaddata()
	{
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		string cmdText = fun.select("*", "tblDG_ECN_Reason", "CompId='" + CompId + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, con);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		GridView1.DataSource = dataSet;
		GridView1.DataBind();
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	public void FillDataGrid()
	{
		try
		{
			SqlCommand selectCommand = new SqlCommand(fun.select("Id,ItemId,ItemCode,ManfDesc,UOMBasic,Qty,PartNo", "tblDG_BOMItem_Temp", "WONo='" + wono + "' AND Childid='" + childid + "' AND SessionId='" + SId + "' AND CompId='" + CompId + "'Order by Id Desc"), con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			double num = fun.RecurQty(wono, parentid, childid, 1.0, CompId, FinYearId);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ItemCode", typeof(string));
			dataTable.Columns.Add("ManfDesc", typeof(string));
			dataTable.Columns.Add("UOMBasic", typeof(string));
			dataTable.Columns.Add("AsslyQty", typeof(string));
			dataTable.Columns.Add("Qty", typeof(double));
			dataTable.Columns.Add("BOMQty", typeof(double));
			dataTable.Columns.Add("Id", typeof(int));
			dataTable.Columns.Add("ItemId", typeof(string));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string value = "";
				string value2 = "";
				string value3 = "";
				if (dataSet.Tables[0].Rows[i]["ItemId"] != DBNull.Value)
				{
					string cmdText = fun.select("tblDG_Item_Master.CId,tblDG_Item_Master.PartNo,tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UBasic", "tblDG_Item_Master,Unit_Master", "tblDG_Item_Master.Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic And tblDG_Item_Master.CompId='" + CompId + "'AND tblDG_Item_Master.FinYearId<='" + FinYearId + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						value = ((dataSet2.Tables[0].Rows[0]["CId"] == DBNull.Value) ? dataSet2.Tables[0].Rows[0]["PartNo"].ToString() : dataSet2.Tables[0].Rows[0]["ItemCode"].ToString());
						value2 = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
						value3 = dataSet2.Tables[0].Rows[0]["UBasic"].ToString();
					}
				}
				else
				{
					value = dataSet.Tables[0].Rows[i]["PartNo"].ToString();
					value2 = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
					SqlCommand selectCommand3 = new SqlCommand(fun.select("Symbol", "Unit_Master", "Id='" + dataSet.Tables[0].Rows[i]["UOMBasic"].ToString() + "'"), con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					value3 = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
				}
				dataRow[0] = value;
				dataRow[1] = value2;
				dataRow[2] = value3;
				dataRow[3] = Convert.ToDouble(decimal.Parse(num.ToString()).ToString("N3"));
				dataRow[4] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
				dataRow[5] = Convert.ToDouble(decimal.Parse((num * Convert.ToDouble(dataSet.Tables[0].Rows[i]["Qty"])).ToString()).ToString("N3"));
				dataRow[6] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
				dataRow[7] = dataSet.Tables[0].Rows[i]["ItemId"].ToString();
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

	public void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblid")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblItemId")).Text;
				string connectionString = fun.Connection();
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				string cmdText = fun.delete("tblDG_BOMItem_Temp", "Id='" + text + "' AND SessionId='" + SId + "' And CompId='" + CompId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.select("Id", "tblDG_ECN_Master_Temp", "ItemId='" + text2 + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
				{
					SqlCommand sqlCommand2 = new SqlCommand(fun.delete("tblDG_ECN_Details_Temp", "MId='" + dataSet.Tables[0].Rows[0][0].ToString() + "'       "), sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					SqlCommand sqlCommand3 = new SqlCommand(fun.delete("tblDG_ECN_Master_Temp", "Id='" + dataSet.Tables[0].Rows[0][0].ToString() + "' and ItemId='" + text2 + "' AND SessionId='" + SId + "' And CompId='" + CompId + "'"), sqlConnection);
					sqlCommand3.ExecuteNonQuery();
				}
				FillDataGrid();
				sqlConnection.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		try
		{
			if (!(e.CommandName == "Add"))
			{
				return;
			}
			GridViewRow gridViewRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
			string text = ((TextBox)gridViewRow.FindControl("txtQty")).Text;
			string text2 = base.Request.QueryString["WONo"].ToString();
			string cmdText = fun.select(" TaskDesignFinalization_TDate", " SD_Cust_WorkOrder_Master", "WONo='" + text2 + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter.Fill(dataSet2);
			string value = dataSet2.Tables[0].Rows[0][0].ToString();
			int num = Convert.ToInt32(base.Request.QueryString["CId"].ToString());
			int num2 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
			string cmdText2 = fun.select("ItemId", "tblDG_BOMItem_Temp", "ItemId='" + num2 + "'And CompId='" + CompId + "' And WONo='" + text2.ToString() + "' And ChildId='" + num + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			sqlDataAdapter2.Fill(dataSet, "tblDG_BOMItem_Temp");
			string cmdText3 = fun.select("ItemId", "tblDG_BOM_Master", "ItemId='" + num2 + "'And CompId='" + CompId + "' And WONo='" + text2.ToString() + "' And PId='" + num + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3, "tblDG_BOM_Master");
			sqlConnection.Open();
			string currDate = fun.getCurrDate();
			if (Convert.ToDateTime(value) >= Convert.ToDateTime(currDate))
			{
				if (text != "")
				{
					if (!fun.NumberValidationQty(text))
					{
						return;
					}
					if (dataSet.Tables[0].Rows.Count == 0 && dataSet3.Tables[0].Rows.Count == 0)
					{
						if (Convert.ToDouble(text) > 0.0)
						{
							string cmdText4 = fun.insert("tblDG_BOMItem_Temp", "CompId,SessionId,WONo,ItemId,Qty,ChildId", "'" + CompId + "','" + SId.ToString() + "','" + text2.ToString() + "','" + num2 + "','" + Convert.ToDouble(decimal.Parse(text.ToString()).ToString("N3")) + "','" + num + "'");
							SqlCommand sqlCommand = new SqlCommand(cmdText4, sqlConnection);
							sqlCommand.ExecuteNonQuery();
							string empty = string.Empty;
							empty = "Record has been Inserted.";
							base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty + "');", addScriptTags: true);
							string selectedValue = DrpCategory1.SelectedValue;
							string selectedValue2 = DrpSearchCode.SelectedValue;
							string text3 = txtSearchItemCode.Text;
							string selectedValue3 = DrpType.SelectedValue;
							Fillgrid(selectedValue, selectedValue2, text3, selectedValue3);
						}
						else
						{
							string empty2 = string.Empty;
							empty2 = "Req. Qty must be greater than zero.";
							base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty2 + "');", addScriptTags: true);
						}
					}
					else
					{
						string empty3 = string.Empty;
						empty3 = "Record Already Inserted";
						base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty3 + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty4 = string.Empty;
					empty4 = "Req. Qty should not be blank.";
					base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty4 + "');", addScriptTags: true);
				}
			}
			else if (text != "")
			{
				if (!fun.NumberValidationQty(text))
				{
					return;
				}
				if (dataSet.Tables[0].Rows.Count == 0 && dataSet3.Tables[0].Rows.Count == 0)
				{
					if (Convert.ToDouble(text) > 0.0)
					{
						base.Response.Redirect("ECN_Master.aspx?ItemId=" + num2 + "&WONo=" + text2 + "&CId=" + num + "&ParentId=" + parentid + "&Qty=" + text + "&asslyNo=" + AsslyNo);
					}
					else
					{
						string empty5 = string.Empty;
						empty5 = "Req. Qty must be greater than zero.";
						base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty5 + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty6 = string.Empty;
					empty6 = "Record Already Inserted";
					base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty6 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty7 = string.Empty;
				empty7 = "Req. Qty should not be blank.";
				base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty7 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = base.Request.QueryString["WONo"].ToString();
			int num = Convert.ToInt32(base.Request.QueryString["CId"].ToString());
			int num2 = Convert.ToInt32(base.Request.QueryString["PId"].ToString());
			string text2 = txtPartNo.Text;
			string text3 = txtUnitNo.Text;
			string text4 = EquipNo + '-' + text3 + '-' + text2 + '0';
			int num3 = 0;
			string text5 = EquipNo + '-' + text3 + '-' + text2;
			fun.ItemCodeLimit(CompId);
			new DataSet();
			string text6 = "";
			double num4 = 0.0;
			string text7 = "";
			HttpPostedFile postedFile = FileUpload1.PostedFile;
			byte[] array = null;
			if (FileUpload1.PostedFile != null)
			{
				Stream inputStream = FileUpload1.PostedFile.InputStream;
				BinaryReader binaryReader = new BinaryReader(inputStream);
				array = binaryReader.ReadBytes((int)inputStream.Length);
				text6 = Path.GetFileName(postedFile.FileName);
				num4 = array.Length;
				text7 = postedFile.ContentType;
			}
			string text8 = "";
			double num5 = 0.0;
			string text9 = "";
			HttpPostedFile postedFile2 = FileUpload2.PostedFile;
			byte[] array2 = null;
			if (FileUpload2.PostedFile != null)
			{
				Stream inputStream2 = FileUpload2.PostedFile.InputStream;
				BinaryReader binaryReader2 = new BinaryReader(inputStream2);
				array2 = binaryReader2.ReadBytes((int)inputStream2.Length);
				text8 = Path.GetFileName(postedFile2.FileName);
				num5 = array2.Length;
				text9 = postedFile2.ContentType;
			}
			string cmdText = fun.select(" TaskDesignFinalization_TDate", " SD_Cust_WorkOrder_Master", "WONo='" + text + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			string value = dataSet.Tables[0].Rows[0][0].ToString();
			if (!(txtQuntity.Text != "") || !fun.NumberValidationQty(txtQuntity.Text) || !(DDLUnitBasic.SelectedItem.Text != "Select") || !(txtManfDescription.Text != ""))
			{
				return;
			}
			string cmdText2 = fun.select("*", "tblDG_Item_Master", "PartNo='" + text5 + "'And CompId='" + CompId + "'And FinYearId<='" + FinYearId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblDG_Item_Master");
			if (dataSet2.Tables[0].Rows.Count == 0 && Convert.ToDouble(txtQuntity.Text) > 0.0)
			{
				string cmdText3 = fun.select("PartNo", "tblDG_BOM_Master", "CompId='" + CompId + "' And PartNo is not null AND PartNo like '" + text5 + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "tblDG_BOM_Master");
				string cmdText4 = fun.select("PartNo", "tblDG_BOMItem_Temp", "CompId='" + CompId + "' And PartNo is not null AND PartNo like '" + text5 + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4, "tblDG_BOMItem_Temp");
				string cmdText5 = fun.select("*", "tblDG_Item_Master", "PartNo like '" + text5 + "' And  CompId='" + CompId + "'And FinYearId<='" + FinYearId + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5, "tblDG_Item_Master");
				num3 = ((!(Convert.ToDateTime(value) >= Convert.ToDateTime(currDate))) ? 1 : 0);
				if (dataSet5.Tables[0].Rows.Count == 0 && dataSet4.Tables[0].Rows.Count == 0 && dataSet3.Tables[0].Rows.Count == 0)
				{
					string cmdText6 = fun.insert("tblDG_BOMItem_Temp", "SessionId,CompId,WONo,EquipmentNo,UnitNo,ChildId,PartNo,ItemCode,Process,ManfDesc,UOMBasic,Qty,ImgFile,ImgName,ImgSize,ImgContentType,SpecSheetName,SpecSheetSize,SpecSheetContentType,SpecSheetData,ECNFlag", "'" + SId.ToString() + "','" + CompId + "','" + text + "','" + EquipNo + "','" + text3 + "','" + num + "','" + text5 + "','" + text4 + "',0,'" + txtManfDescription.Text + "','" + DDLUnitBasic.SelectedValue + "','" + Convert.ToDouble(decimal.Parse(txtQuntity.Text.ToString()).ToString("N3")) + "',@pic,'" + text6 + "','" + num4 + "','" + text7 + "','" + text8 + "','" + num5 + "','" + text9 + "',@AttData,'" + num3 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText6, sqlConnection);
					sqlCommand.Parameters.AddWithValue("@pic", array);
					sqlCommand.Parameters.AddWithValue("@AttData", array2);
					TabContainer1.ActiveTab = TabContainer1.Tabs[1];
					txtUnitNo.Text = "";
					txtPartNo.Text = "";
					txtQuntity.Text = "";
					txtManfDescription.Text = "";
					fun.drpunit(DDLUnitBasic);
					if (Convert.ToDateTime(value) < Convert.ToDateTime(currDate))
					{
						int num6 = 1;
						string text10 = "";
						int num7 = 0;
						int num8 = 0;
						int num9 = 0;
						foreach (GridViewRow row in GridView1.Rows)
						{
							if (((CheckBox)row.FindControl("CheckBox1")).Checked)
							{
								string text11 = ((Label)row.FindControl("lblId55")).Text;
								string text12 = ((TextBox)row.FindControl("TxtRemarks")).Text;
								if (num6 == 1)
								{
									sqlCommand.ExecuteNonQuery();
									int num10 = 0;
									string cmdText7 = fun.select("Id", "tblDG_BOMItem_Temp", "CompId='" + CompId + "' Order by Id Desc");
									SqlCommand selectCommand6 = new SqlCommand(cmdText7, sqlConnection);
									SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
									DataSet dataSet6 = new DataSet();
									sqlDataAdapter6.Fill(dataSet6);
									num10 = Convert.ToInt32(dataSet6.Tables[0].Rows[0]["Id"]);
									string cmdText8 = fun.insert("tblDG_ECN_Master_Temp", "MId,SysDate,SysTime,CompId,FinYearId,SessionId,ItemId,WONo,PId,CId,ItemCOde", "'" + num10 + "','" + currDate + "','" + currTime + "','" + CompId + "','" + FinYearId + "','" + SId + "','" + num9 + "','" + text + "','" + num2 + "','" + num + "','" + text4 + "'");
									SqlCommand sqlCommand2 = new SqlCommand(cmdText8, sqlConnection);
									sqlCommand2.ExecuteNonQuery();
									num6 = 0;
									string cmdText9 = fun.select("Id", "tblDG_ECN_Master_Temp", "CompId='" + CompId + "' Order by Id Desc");
									SqlCommand selectCommand7 = new SqlCommand(cmdText9, sqlConnection);
									SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
									DataSet dataSet7 = new DataSet();
									sqlDataAdapter7.Fill(dataSet7);
									text10 = dataSet7.Tables[0].Rows[0]["Id"].ToString();
								}
								string cmdText10 = fun.insert("tblDG_ECN_Details_Temp", "MId,ECNReason,Remarks", "'" + text10 + "','" + text11 + "','" + text12 + "'");
								SqlCommand sqlCommand3 = new SqlCommand(cmdText10, sqlConnection);
								sqlCommand3.ExecuteNonQuery();
								num7++;
							}
							else
							{
								num8++;
							}
						}
						if (num8 > 0)
						{
							string empty = string.Empty;
							empty = " Enter reasons in Grid!";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
							CreateNextUnitPartNo();
							TabContainer1.ActiveTabIndex = 1;
						}
						if (num7 > 0)
						{
							Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
						}
					}
					else
					{
						sqlCommand.ExecuteNonQuery();
						Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
						CreateNextUnitPartNo();
						TabContainer1.ActiveTabIndex = 1;
					}
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Record Already Exists!";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty3 = string.Empty;
				empty3 = "Record Already Exists!";
				base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty3 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("BOM_Design_WO_TreeView.aspx?WONo=" + wono + "&ModId=3&SubModId=26");
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}

	public void AddToTPLBOM(int cnv)
	{
		try
		{
			string text = base.Request.QueryString["WONo"].ToString();
			int num = Convert.ToInt32(base.Request.QueryString["PId"]);
			int num2 = Convert.ToInt32(base.Request.QueryString["CId"]);
			string currDate = fun.getCurrDate();
			string currDate2 = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			con.Open();
			int num3 = 0;
			string cmdText = fun.select("*", "tblDG_BOMItem_Temp", "CompId='" + CompId + "'And SessionId='" + SId.ToString() + "'And WONo='" + text.ToString() + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblDG_BOMItem_Temp");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					int bOMCId = fun.getBOMCId(text, CompId, FinYearId);
					if (dataSet.Tables[0].Rows[i]["ItemId"] == DBNull.Value)
					{
						string cmdText2 = fun.select("*", "tblDG_Item_Master", "ItemCode='" + dataSet.Tables[0].Rows[i]["ItemCode"].ToString() + "'And CompId='" + CompId + "'And FinYearId<='" + FinYearId + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2, "tblDG_Item_Master");
						if (dataSet2.Tables[0].Rows.Count == 0)
						{
							string text2 = fun.FromDate(fun.getOpeningDate(CompId, FinYearId));
							byte[] value = (byte[])dataSet.Tables[0].Rows[i]["ImgFile"];
							byte[] value2 = (byte[])dataSet.Tables[0].Rows[i]["SpecSheetData"];
							string cmdText3 = fun.insert("tblDG_Item_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PartNo,ItemCode,ManfDesc,UOMBasic,OpeningBalDate,FileName,FileSize,ContentType,FileData,AttName,AttSize,AttContentType,AttData", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + CompId + "','" + FinYearId + "','" + dataSet.Tables[0].Rows[i]["SessionId"].ToString() + "','" + dataSet.Tables[0].Rows[i]["PartNo"].ToString() + "','" + dataSet.Tables[0].Rows[i]["ItemCode"].ToString() + "','" + dataSet.Tables[0].Rows[i]["ManfDesc"].ToString() + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["UOMBasic"]) + "','" + text2 + "','" + dataSet.Tables[0].Rows[i]["ImgName"].ToString() + "','" + dataSet.Tables[0].Rows[i]["ImgSize"].ToString() + "','" + dataSet.Tables[0].Rows[i]["ImgContentType"].ToString() + "',@pic,'" + dataSet.Tables[0].Rows[i]["SpecSheetName"].ToString() + "','" + dataSet.Tables[0].Rows[i]["SpecSheetSize"].ToString() + "','" + dataSet.Tables[0].Rows[i]["SpecSheetContentType"].ToString() + "',@AttData");
							SqlCommand sqlCommand = new SqlCommand(cmdText3, con);
							sqlCommand.Parameters.AddWithValue("@pic", value);
							sqlCommand.Parameters.AddWithValue("@AttData", value2);
							sqlCommand.ExecuteNonQuery();
							string cmdText4 = fun.select("*", "tblDG_Item_Master", "ItemCode='" + dataSet.Tables[0].Rows[i]["ItemCode"].ToString() + "'And CompId='" + CompId + "'And FinYearId<='" + FinYearId + "'");
							SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
							DataSet dataSet3 = new DataSet();
							sqlDataAdapter3.Fill(dataSet3, "tblDG_Item_Master");
							num3 = Convert.ToInt32(dataSet3.Tables[0].Rows[0]["Id"]);
							if (dataSet3.Tables[0].Rows.Count > 0)
							{
								string cmdText5 = fun.select("ItemId", "tblDG_BOM_Master", "CompId='" + CompId + "'And FinYearId<='" + FinYearId + "'And WONo='" + text.ToString() + "'And PId='" + num.ToString() + "'And CId='" + num2.ToString() + "' And ItemId='" + dataSet3.Tables[0].Rows[0]["Id"].ToString() + "'");
								SqlCommand selectCommand4 = new SqlCommand(cmdText5, con);
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
								DataSet dataSet4 = new DataSet();
								sqlDataAdapter4.Fill(dataSet4, "tblDG_BOM_Master");
								if (dataSet4.Tables[0].Rows.Count == 0)
								{
									string cmdText6 = fun.insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,WONo,PId,CId,ItemId,Qty,PartNo,EquipmentNo,UnitNo,ECNFlag", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + CompId + "','" + FinYearId + "','" + SId.ToString() + "','" + text.ToString() + "','" + num2.ToString() + "','" + bOMCId + "','" + dataSet3.Tables[0].Rows[0]["Id"].ToString() + "','" + dataSet.Tables[0].Rows[i]["Qty"].ToString() + "','" + dataSet.Tables[0].Rows[i]["PartNo"].ToString() + "','" + dataSet.Tables[0].Rows[i]["EquipmentNo"].ToString() + "','" + dataSet.Tables[0].Rows[i]["UnitNo"].ToString() + "','" + dataSet.Tables[0].Rows[i]["ECNFLag"].ToString() + "'");
									SqlCommand sqlCommand2 = new SqlCommand(cmdText6, con);
									sqlCommand2.ExecuteNonQuery();
									string cmdText7 = fun.update("SD_Cust_WorkOrder_Master", "UpdateWO='1'", "WONo='" + text + "' And  CompId='" + CompId + "' ");
									SqlCommand sqlCommand3 = new SqlCommand(cmdText7, con);
									sqlCommand3.ExecuteNonQuery();
								}
							}
						}
					}
					else
					{
						string cmdText8 = fun.select("Id", "tblDG_Item_Master", "CompId='" + CompId + "'And FinYearId<='" + FinYearId + "'And Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "' ");
						SqlCommand selectCommand5 = new SqlCommand(cmdText8, con);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5, "tblDG_Item_Master");
						if (dataSet5.Tables[0].Rows.Count > 0)
						{
							string cmdText9 = fun.select("ItemId", "tblDG_BOM_Master", "CompId='" + CompId + "'And FinYearId<='" + FinYearId + "'And WONo='" + text.ToString() + "'And PId='" + num2.ToString() + "' And ItemId='" + dataSet5.Tables[0].Rows[0]["Id"].ToString() + "' ");
							SqlCommand selectCommand6 = new SqlCommand(cmdText9, con);
							SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
							DataSet dataSet6 = new DataSet();
							sqlDataAdapter6.Fill(dataSet6, "tblDG_BOM_Master");
							if (dataSet6.Tables[0].Rows.Count == 0)
							{
								string cmdText10 = fun.insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,WONo,PId,CId,ItemId,Qty,ECNFLag", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + CompId + "','" + FinYearId + "','" + SId.ToString() + "','" + text.ToString() + "','" + num2.ToString() + "','" + bOMCId + "','" + dataSet5.Tables[0].Rows[0]["Id"].ToString() + "','" + dataSet.Tables[0].Rows[i]["Qty"].ToString() + "','" + dataSet.Tables[0].Rows[i]["ECNFLag"].ToString() + "'");
								SqlCommand sqlCommand4 = new SqlCommand(cmdText10, con);
								sqlCommand4.ExecuteNonQuery();
								string cmdText11 = fun.update("SD_Cust_WorkOrder_Master", "UpdateWO='1'", "WONo='" + text + "' And  CompId='" + CompId + "' ");
								SqlCommand sqlCommand5 = new SqlCommand(cmdText11, con);
								sqlCommand5.ExecuteNonQuery();
							}
						}
					}
					string cmdText12 = fun.select("Id,WONo,ItemId,PId,CId,ItemCode", "tblDG_ECN_Master_Temp", "CompId='" + CompId + "'And SessionId='" + SId.ToString() + "'And WONo='" + text.ToString() + "' And MId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]) + "'");
					SqlCommand selectCommand7 = new SqlCommand(cmdText12, con);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter7.Fill(dataSet7);
					int num4 = 0;
					for (int j = 0; j < dataSet7.Tables[0].Rows.Count; j++)
					{
						num4 = ((Convert.ToInt32(dataSet7.Tables[0].Rows[j]["ItemId"]) != 0) ? Convert.ToInt32(dataSet7.Tables[0].Rows[j]["ItemId"]) : num3);
						string cmdText13 = fun.insert("tblDG_ECN_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,ItemId,WONo,PId,CId", "'" + currDate2 + "','" + currTime + "','" + CompId + "','" + FinYearId + "','" + SId + "','" + num4 + "','" + dataSet7.Tables[0].Rows[j]["WONo"].ToString() + "','" + dataSet7.Tables[0].Rows[j]["PId"].ToString() + "','" + dataSet7.Tables[0].Rows[j]["CId"].ToString() + "'");
						SqlCommand sqlCommand6 = new SqlCommand(cmdText13, con);
						sqlCommand6.ExecuteNonQuery();
						string cmdText14 = fun.select("Id", "tblDG_ECN_Master", "CompId='" + CompId + "'And SessionId='" + SId.ToString() + "'And WONo='" + text.ToString() + "'  order by Id Desc");
						SqlCommand selectCommand8 = new SqlCommand(cmdText14, con);
						SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
						DataSet dataSet8 = new DataSet();
						sqlDataAdapter8.Fill(dataSet8);
						string cmdText15 = fun.select("*", "tblDG_ECN_Details_Temp", "MId='" + dataSet7.Tables[0].Rows[0]["Id"].ToString() + "'");
						SqlCommand selectCommand9 = new SqlCommand(cmdText15, con);
						SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
						DataSet dataSet9 = new DataSet();
						sqlDataAdapter9.Fill(dataSet9);
						for (int k = 0; k < dataSet9.Tables[0].Rows.Count; k++)
						{
							string cmdText16 = fun.insert("tblDG_ECN_Details", "MId,ECNReason,Remarks", "'" + dataSet8.Tables[0].Rows[0]["Id"].ToString() + "','" + dataSet9.Tables[0].Rows[k]["ECNReason"].ToString() + "','" + dataSet9.Tables[0].Rows[k]["Remarks"].ToString() + "'");
							SqlCommand sqlCommand7 = new SqlCommand(cmdText16, con);
							sqlCommand7.ExecuteNonQuery();
						}
					}
				}
			}
			string cmdText17 = fun.select("Id", "tblDG_ECN_Master_Temp", " SessionId='" + SId + "' And CompId='" + CompId + "'");
			SqlCommand selectCommand10 = new SqlCommand(cmdText17, con);
			SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
			DataSet dataSet10 = new DataSet();
			sqlDataAdapter10.Fill(dataSet10);
			for (int l = 0; l < dataSet10.Tables[0].Rows.Count; l++)
			{
				string cmdText18 = fun.delete("tblDG_ECN_Details_Temp", "MId='" + dataSet10.Tables[0].Rows[l][0].ToString() + "'");
				SqlCommand sqlCommand8 = new SqlCommand(cmdText18, con);
				sqlCommand8.ExecuteNonQuery();
				string cmdText19 = fun.delete("tblDG_ECN_Master_Temp", "Id='" + dataSet10.Tables[0].Rows[l][0].ToString() + "'");
				SqlCommand sqlCommand9 = new SqlCommand(cmdText19, con);
				sqlCommand9.ExecuteNonQuery();
			}
			clearTempDb(CompId, SId, text);
			base.Response.Redirect("BOM_Design_WO_TreeView.aspx?WONo=" + text + "&ModId=3&SubModId=26");
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	public void clearTempDb(int getCId, string getSId, string getwono)
	{
		try
		{
			string cmdText = fun.delete("tblDG_BOMItem_Temp", "CompId='" + getCId + "'And SessionId='" + getSId + "'And WONo='" + getwono + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			sqlCommand.ExecuteNonQuery();
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click1(object sender, EventArgs e)
	{
		base.Response.Redirect("BOM_Design_WO_TreeView.aspx?WONo=" + wono + "&ModId=3&SubModId=26");
	}

	protected void btnaddtobom_Click(object sender, EventArgs e)
	{
		AddToTPLBOM(1);
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
				DrpCategory1.Visible = false;
				DrpCategory1.Items.Clear();
				DrpCategory1.Items.Insert(0, "Select");
				DropDownList3.Visible = false;
				DropDownList3.Items.Clear();
				DropDownList3.Items.Insert(0, "Select");
				break;
			case "Select":
			{
				string empty = string.Empty;
				empty = "Please Select Category or WO Items.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				break;
			}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView3.PageIndex = e.NewPageIndex;
			FillDataGrid();
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
}

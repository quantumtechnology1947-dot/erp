using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Design_Transactions_WoItems : Page, IRequiresSessionState
{
	protected Label lblwono;

	protected Label lblasslyno;

	protected DropDownList DrpCategory;

	protected DropDownList DrpSubCategory;

	protected DropDownList DrpSearchCode;

	protected TextBox txtSearchItemCode;

	protected DropDownList DropDownList3;

	protected Button btnSearch;

	protected Button btnCancel;

	protected GridView GridView2;

	protected TabPanel TabPanel1;

	protected DropDownList DDLCategory;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected Label lblWo;

	protected TextBox txtPartNo;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox TxtCounter;

	protected CheckBox CKRevision;

	protected TextBox txtManfDescription;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected TextBox txtPurchDescription;

	protected RequiredFieldValidator RequiredFieldValidator5;

	protected DropDownList DDLUnitBasic;

	protected RequiredFieldValidator RequiredFieldValidator6;

	protected DropDownList DDLUnitPurchase;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected TextBox txtQuntity;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegQty;

	protected Button btnSubmit;

	protected Button Button1;

	protected Label lblMsg1;

	protected Label lblMsg;

	protected TabPanel TabPanel2;

	protected HtmlGenericControl frm2;

	protected Button Button3;

	protected TabPanel TabPanel3;

	protected GridView GridView4;

	protected Button btnproceed;

	protected Button btnCovBom;

	protected Button Button4;

	protected TabPanel TabPanel4;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private string wono = "";

	private int wlen;

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private string SId = "";

	private int FinYearId;

	private int parentid;

	private int childid;

	private string AsslyNo = "";

	private DataSet dsnm = new DataSet();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	public void Fillgridview(string sd, string A, string B, string s)
	{
		try
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			List<int> list = new List<int>();
			list = fun.getTPLBOMRootnode(childid, wono, CompId, SId, FinYearId, "tblDG_TPL_Master");
			if (list.Count > 0)
			{
				text3 = "and tblDG_Item_Master.Id!='" + list[0] + "'";
			}
			if (sd != "Select Category")
			{
				string text4 = "";
				if (A != "Select SubCategory")
				{
					text4 = "  And tblDG_Item_Master.SCId='" + A + "'";
				}
				text2 = " AND  tblDG_Item_Master.CId='" + sd + "'";
				string text5 = "";
				txtSearchItemCode.Visible = true;
				if (B != "Select")
				{
					if (B == "tblDG_Item_Master.ItemCode")
					{
						txtSearchItemCode.Visible = true;
						text5 = " And tblDG_Item_Master.ItemCode Like '" + s + "%'";
					}
					if (B == "tblDG_Item_Master.ManfDesc")
					{
						txtSearchItemCode.Visible = true;
						text5 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
					}
					if (B == "tblDG_Item_Master.PurchDesc")
					{
						txtSearchItemCode.Visible = true;
						text5 = " And tblDG_Item_Master.PurchDesc Like '%" + s + "%'";
					}
					if (B == "tblDG_Item_Master.Location")
					{
						txtSearchItemCode.Visible = false;
						DropDownList3.Visible = true;
						text5 = " And tblDG_Item_Master.Location='" + DropDownList3.SelectedValue + "'";
					}
				}
				text = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,tblDG_Item_Master.StockQty,tblDG_Item_Master.PurchDesc,Unit_Master.Symbol As UOMBasic,vw_Unit_Master.Symbol As UOMPurchase, tblDG_Item_Master.ItemCode,tblDG_Item_Master.Location", "tblDG_Category_Master,Unit_Master,vw_Unit_Master,tblDG_Item_Master", "tblDG_Item_Master.CId=tblDG_Category_Master.CId and Unit_Master.Id=tblDG_Item_Master.UOMBasic and vw_Unit_Master.Id=tblDG_Item_Master.UOMPurchase" + text2 + text4 + text5 + " AND tblDG_Item_Master.CompId='" + CompId + "'AND tblDG_Item_Master.FinYearId<='" + FinYearId + "'AND tblDG_Item_Master.Id!='" + AsslyNo + "' And tblDG_Item_Master.Absolute!='1'" + text3 + " ");
			}
			else
			{
				text = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,tblDG_Item_Master.StockQty,tblDG_Item_Master.PurchDesc,Unit_Master.Symbol As UOMBasic,vw_Unit_Master.Symbol As UOMPurchase, tblDG_Item_Master.ItemCode,tblDG_Item_Master.Location", " tblDG_Category_Master,tblDG_Item_Master,Unit_Master,vw_Unit_Master", "tblDG_Item_Master.CId=tblDG_Category_Master.CId and Unit_Master.Id=tblDG_Item_Master.UOMBasic and vw_Unit_Master.Id=tblDG_Item_Master.UOMPurchase AND tblDG_Item_Master.CompId='" + CompId + "'AND tblDG_Item_Master.FinYearId<='" + FinYearId + "'AND tblDG_Item_Master.Id!='" + AsslyNo + "' And tblDG_Item_Master.Absolute!='1'" + text3 + " ");
			}
			fun.binddropdwn(text, GridView2, CompId);
		}
		catch (Exception)
		{
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		try
		{
			DropDownList3.Visible = false;
			lblMsg.Text = "";
			lblMsg1.Text = "";
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			wono = base.Request.QueryString["WONo"].ToString();
			wlen = wono.Length;
			AsslyNo = base.Request.QueryString["ItemId"];
			parentid = Convert.ToInt32(base.Request.QueryString["PId"]);
			childid = Convert.ToInt32(base.Request.QueryString["CId"]);
			if (!base.IsPostBack)
			{
				fun.drpDesignCategory(DrpCategory, DrpSubCategory);
				fun.drpCategoryOnly(DDLCategory);
				fun.drpunit(DDLUnitBasic);
				fun.drpunit(DDLUnitPurchase);
				if (DrpSearchCode.SelectedValue == "Select")
				{
					DropDownList3.Visible = false;
					txtSearchItemCode.Visible = true;
				}
				string cmdText = fun.select1("Id,LocationLabel+''+tblDG_Location_Master.LocationNo As Location", "tblDG_Location_Master");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblDG_Location_Master");
				DropDownList3.DataSource = dataSet.Tables["tblDG_Location_Master"];
				DropDownList3.DataTextField = "Location";
				DropDownList3.DataValueField = "Id";
				DropDownList3.DataBind();
				DropDownList3.Items.Insert(0, "Select");
				string selectedValue = DrpCategory.SelectedValue;
				string selectedValue2 = DrpSubCategory.SelectedValue;
				string selectedValue3 = DrpSearchCode.SelectedValue;
				string text = txtSearchItemCode.Text;
				Fillgridview(selectedValue, selectedValue2, selectedValue3, text);
				TabContainer1.OnClientActiveTabChanged = "OnChanged";
				TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
			}
			lblwono.Text = wono.ToString();
			SqlCommand selectCommand2 = new SqlCommand(fun.select("ItemCode", "tblDG_Item_Master", "Id='" + AsslyNo + "'AND CompId='" + CompId + "'AND FinYearId<='" + FinYearId + "'"), con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				lblasslyno.Text = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
			}
			frm2.Attributes["src"] = "TPL_Design_CopyWo.aspx?WONoDest=" + wono + "&DestPId=" + parentid + "&DestCId=" + childid;
			FillDatagrid();
			int num = 0;
			int limit = fun.ItemCodeLimit(CompId);
			num = fun.SetBomItemLimit(limit, wlen);
			txtPartNo.MaxLength = num;
			TxtCounter.Text = num.ToString();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	public void FillDatagrid()
	{
		try
		{
			SqlCommand selectCommand = new SqlCommand(fun.select("*", "tblDG_TPLItem_Temp", "WONo='" + wono + "' AND Childid='" + childid + "' AND CompId='" + CompId + "'Order by Id Desc"), con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			double num = fun.RecurQty(wono, parentid, childid, 1.0, CompId, FinYearId);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ItemCode", typeof(string));
			dataTable.Columns.Add("ManfDesc", typeof(string));
			dataTable.Columns.Add("UOMBasic", typeof(string));
			dataTable.Columns.Add("PurchDesc", typeof(string));
			dataTable.Columns.Add("UOMPurchase", typeof(string));
			dataTable.Columns.Add("AsslyQty", typeof(string));
			dataTable.Columns.Add("Qty", typeof(double));
			dataTable.Columns.Add("BOMQty", typeof(double));
			dataTable.Columns.Add("Id", typeof(int));
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows[i]["ItemId"] != DBNull.Value)
				{
					SqlCommand selectCommand2 = new SqlCommand(fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,tblDG_Item_Master.PurchDesc,Unit_Master.Symbol As UBasic,vw_Unit_Master.Symbol As UPurch", "tblDG_Item_Master,vw_Unit_Master,Unit_Master", "tblDG_Item_Master.Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND vw_Unit_Master.Id=tblDG_Item_Master.UOMPurchase AND tblDG_Item_Master.CompId='" + CompId + "'AND tblDG_Item_Master.FinYearId<='" + FinYearId + "'"), con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					text = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
					text2 = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
					text3 = dataSet2.Tables[0].Rows[0]["PurchDesc"].ToString();
					text4 = dataSet2.Tables[0].Rows[0]["UBasic"].ToString();
					text5 = dataSet2.Tables[0].Rows[0]["UPurch"].ToString();
				}
				else
				{
					text = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
					text2 = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
					text3 = dataSet.Tables[0].Rows[i]["PurchDesc"].ToString();
					SqlCommand selectCommand3 = new SqlCommand(fun.select("Symbol", "Unit_Master", "Id='" + dataSet.Tables[0].Rows[i]["UOMBasic"].ToString() + "'"), con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					text4 = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
					SqlCommand selectCommand4 = new SqlCommand(fun.select("Symbol", "Unit_Master", "Id='" + dataSet.Tables[0].Rows[i]["UOMPurchase"].ToString() + "'"), con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					text5 = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
				}
				dataRow[0] = text;
				dataRow[1] = text2;
				dataRow[2] = text4;
				dataRow[3] = text3;
				dataRow[4] = text5;
				dataRow[5] = Convert.ToDouble(decimal.Parse(num.ToString()).ToString("N3"));
				dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
				dataRow[7] = Convert.ToDouble(decimal.Parse((num * Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"))).ToString()).ToString("N3"));
				dataRow[8] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView4.DataSource = dataTable;
			GridView4.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	public void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblid")).Text;
				string text2 = Session["username"].ToString();
				string connectionString = fun.Connection();
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				string cmdText = fun.delete("tblDG_TPLItem_Temp ", "Id='" + text + "' AND SessionId='" + text2 + "' AND CompId='" + CompId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}

	public void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
	}

	public void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
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
			int num = Convert.ToInt32(Session["compid"]);
			string text2 = Session["username"].ToString();
			string text3 = base.Request.QueryString["WONo"].ToString();
			int num2 = Convert.ToInt32(base.Request.QueryString["CId"].ToString());
			int num3 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
			string cmdText = fun.select("ItemId", "tblDG_TPLItem_Temp", "ItemId='" + num3 + "'And CompId='" + CompId + "'And SessionId='" + text2 + "'And WONo='" + text3.ToString() + "' And ChildId='" + num2 + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_TPLItem_Temp");
			sqlConnection.Open();
			string cmdText2 = fun.select("Weldments", "tblDG_TPL_Master", "ItemId='" + AsslyNo + "'And CompId='" + CompId + "'And WONo='" + text3.ToString() + "' And CId='" + num2 + "' ");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblDG_TPL_Master");
			int num4 = 0;
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				num4 = ((Convert.ToInt32(dataSet2.Tables[0].Rows[0][0]) == 1) ? 1 : 0);
			}
			if (text != "")
			{
				if (!fun.NumberValidationQty(text))
				{
					return;
				}
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					if (Convert.ToDouble(text) > 0.0)
					{
						string cmdText3 = fun.insert("tblDG_TPLItem_Temp", "CompId,SessionId,WONo,ItemId,Qty,ChildId", "'" + num + "','" + text2.ToString() + "','" + text3.ToString() + "','" + num3 + "','" + text.ToString() + "','" + num2 + "','" + num4 + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText3, sqlConnection);
						sqlCommand.ExecuteNonQuery();
						Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					}
					else
					{
						string empty = string.Empty;
						empty = "Req.Qty must be greater than zero.";
						base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Record Already Inserted";
					base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty3 = string.Empty;
				empty3 = "Req. Qty should not be blank.";
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

	public void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

	protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (DrpCategory.SelectedValue != "Select Category")
			{
				string cmdText = fun.select("CId,SCId,Symbol+' - '+SCName As SubCatName", "tblDG_SubCategory_Master", "CId=" + DrpCategory.SelectedValue + "AND CompId='" + CompId + "'AND FinYearId<='" + FinYearId + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
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
			}
			txtSearchItemCode.Text = "";
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void DrpSubCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DrpSubCategory.SelectedItem.Text != "Select SubCategory")
			{
				string selectedValue = DrpCategory.SelectedValue;
				string selectedValue2 = DrpSubCategory.SelectedValue;
				string selectedValue3 = DrpSearchCode.SelectedValue;
				string text = txtSearchItemCode.Text;
				Fillgridview(selectedValue, selectedValue2, selectedValue3, text);
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
			fun.getCurrDate();
			fun.getCurrTime();
			int num = Convert.ToInt32(Session["compid"]);
			int num2 = Convert.ToInt32(Session["finyear"]);
			string text = Session["username"].ToString();
			string text2 = base.Request.QueryString["WONo"].ToString();
			int num3 = Convert.ToInt32(base.Request.QueryString["CId"].ToString());
			Convert.ToInt32(base.Request.QueryString["PId"].ToString());
			int num4 = 0;
			if (CKRevision.Checked)
			{
				DataSet dataSet = new DataSet();
				string cmdText = fun.select("*", "tblDG_Item_Master", "CompId='" + num + "'AND FinYearId<='" + num2 + "'AND CId='" + DDLCategory.SelectedValue + "'AND PartNo='" + text2 + txtPartNo.Text + "' Order by Id Desc");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				sqlDataAdapter.Fill(dataSet, "tblDG_Item_Master");
				sqlCommand.ExecuteNonQuery();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					num4 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Revision"]) + 1;
					_ = num4 + " revision of";
				}
				else
				{
					num4 = 0;
				}
			}
			else
			{
				num4 = 0;
			}
			string text3 = text2 + txtPartNo.Text;
			int cid = Convert.ToInt32(DDLCategory.SelectedValue);
			string text4 = fun.createAssemblyCode(cid, text3, num4, num, num2);
			if (!(txtQuntity.Text != "") || !fun.NumberValidationQty(txtQuntity.Text))
			{
				return;
			}
			string cmdText2 = fun.select("*", "tblDG_TPLItem_Temp", "ChildId='" + num3 + "' AND WONo='" + text2 + "' AND CompId='" + num + "'AND ItemCode='" + text4 + "'");
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblDG_Item_Master");
			sqlCommand2.ExecuteNonQuery();
			if (num4 < 10 && dataSet2.Tables[0].Rows.Count == 0)
			{
				if (Convert.ToDouble(txtQuntity.Text) > 0.0)
				{
					int num5 = 0;
					int limit = fun.ItemCodeLimit(num);
					num5 = fun.SetBomItemLimit(limit, wlen);
					txtPartNo.MaxLength = num5;
					if (txtPartNo.Text.Length == txtPartNo.MaxLength)
					{
						string cmdText3 = fun.insert("tblDG_TPLItem_Temp", "SessionId,CompId,WONo,CId,ChildId,PartNo,Revision,ItemCode,ManfDesc,PurchDesc,UOMBasic,UOMPurchase,Qty", "'" + text.ToString() + "','" + num + "','" + text2 + "','" + DDLCategory.SelectedValue + "','" + num3 + "','" + text3 + "','" + num4.ToString() + "','" + text4 + "','" + txtManfDescription.Text + "','" + txtPurchDescription.Text + "','" + DDLUnitBasic.SelectedValue + "','" + DDLUnitPurchase.SelectedValue + "','" + txtQuntity.Text + "'");
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
						sqlCommand3.ExecuteNonQuery();
						Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					}
					else
					{
						string empty = string.Empty;
						string text5 = "Part number should be";
						string text6 = "digit.";
						string text7 = Convert.ToString(num5);
						empty = text5 + " " + text7 + " " + text6;
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Req.Qty must be greater than zero.";
					base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty3 = string.Empty;
				empty3 = "Record Already Inserted!";
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
		base.Response.Redirect("TPL_Design_WO_TreeView.aspx?WONo=" + wono + "&ModId=3&SubModId=23");
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
			string currTime = fun.getCurrTime();
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.select("*", "tblDG_TPLItem_Temp", "CompId='" + CompId + "'And SessionId='" + SId.ToString() + "'And WONo='" + text.ToString() + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblDG_TPLItem_Temp");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					int tPLCId = fun.getTPLCId(text, CompId, FinYearId);
					if (dataSet.Tables[0].Rows[i]["ItemId"] == DBNull.Value)
					{
						string cmdText2 = fun.select("*", "tblDG_Item_Master", "ItemCode='" + dataSet.Tables[0].Rows[i]["ItemCode"].ToString() + "'And CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2, "tblDG_Item_Master");
						if (dataSet2.Tables[0].Rows.Count == 0)
						{
							string text2 = fun.FromDate(fun.getOpeningDate(Convert.ToInt32(dataSet.Tables[0].Rows[i]["CompId"]), FinYearId));
							string cmdText3 = fun.insert("tblDG_Item_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,CId,PartNo,Revision,ItemCode,ManfDesc,PurchDesc,UOMBasic,UOMPurchase,OpeningBalDate,OpeningBalQty", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["CompId"]) + "','" + FinYearId + "','" + dataSet.Tables[0].Rows[i]["SessionId"].ToString() + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]) + "','" + dataSet.Tables[0].Rows[i]["PartNo"].ToString() + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["Revision"]) + "','" + dataSet.Tables[0].Rows[i]["ItemCode"].ToString() + "','" + dataSet.Tables[0].Rows[i]["ManfDesc"].ToString() + "','" + dataSet.Tables[0].Rows[i]["PurchDesc"].ToString() + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["UOMBasic"]) + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["UOMPurchase"]) + "','" + text2 + "','0'");
							SqlCommand sqlCommand = new SqlCommand(cmdText3, sqlConnection);
							sqlCommand.ExecuteNonQuery();
						}
						string cmdText4 = fun.select("*", "tblDG_Item_Master", "ItemCode='" + dataSet.Tables[0].Rows[i]["ItemCode"].ToString() + "'And CompId='" + CompId + "'AND FinYearId<='" + FinYearId + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3, "tblDG_Item_Master");
						string cmdText5 = fun.select("ItemId", "tblDG_TPL_Master", " CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "'And WONo='" + text.ToString() + "'And PId='" + num.ToString() + "'And CId='" + num2.ToString() + "' And ItemId='" + dataSet3.Tables[0].Rows[0]["Id"].ToString() + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText5, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4, "tblDG_TPL_Master");
						if (dataSet4.Tables[0].Rows.Count == 0)
						{
							string cmdText6 = fun.insert("tblDG_TPL_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,WONo,PId,CId,ItemId,Qty,ConvertToBOM,Weldments", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + CompId + "','" + FinYearId + "','" + SId.ToString() + "','" + text.ToString() + "','" + num2.ToString() + "','" + tPLCId + "','" + dataSet3.Tables[0].Rows[0]["Id"].ToString() + "','" + dataSet.Tables[0].Rows[i]["Qty"].ToString() + "','" + cnv + "','" + dataSet.Tables[0].Rows[i]["Weldments"].ToString() + "'");
							SqlCommand sqlCommand2 = new SqlCommand(cmdText6, sqlConnection);
							sqlCommand2.ExecuteNonQuery();
							if (cnv == 1)
							{
								string cmdText7 = fun.insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,WONo,PId,CId,ItemId,Qty,Weldments", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + CompId + "','" + FinYearId + "','" + SId.ToString() + "','" + text.ToString() + "','" + num2.ToString() + "','" + tPLCId + "','" + dataSet3.Tables[0].Rows[0]["Id"].ToString() + "','" + dataSet.Tables[0].Rows[i]["Qty"].ToString() + "','" + dataSet.Tables[0].Rows[i]["Weldments"].ToString() + "'");
								SqlCommand sqlCommand3 = new SqlCommand(cmdText7, sqlConnection);
								sqlCommand3.ExecuteNonQuery();
								string cmdText8 = fun.update("SD_Cust_WorkOrder_Master", "UpdateWO='1'", "WONo='" + text + "' And  CompId='" + CompId + "' ");
								SqlCommand sqlCommand4 = new SqlCommand(cmdText8, sqlConnection);
								sqlCommand4.ExecuteNonQuery();
							}
						}
						continue;
					}
					string cmdText9 = fun.select("Id", "tblDG_Item_Master", " CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "'And Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "' ");
					SqlCommand selectCommand5 = new SqlCommand(cmdText9, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5, "tblDG_Item_Master");
					if (dataSet5.Tables[0].Rows.Count <= 0)
					{
						continue;
					}
					string cmdText10 = fun.select("ItemId", "tblDG_TPL_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "'And WONo='" + text.ToString() + "'And PId='" + num2.ToString() + "' And ItemId='" + dataSet5.Tables[0].Rows[0]["Id"].ToString() + "' ");
					SqlCommand selectCommand6 = new SqlCommand(cmdText10, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6, "tblDG_TPL_Master");
					if (dataSet6.Tables[0].Rows.Count == 0)
					{
						string cmdText11 = fun.insert("tblDG_TPL_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,WONo,PId,CId,ItemId,Qty,ConvertToBOM,Weldments", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + CompId + "','" + FinYearId + "','" + SId.ToString() + "','" + text.ToString() + "','" + num2.ToString() + "','" + tPLCId + "','" + dataSet5.Tables[0].Rows[0]["Id"].ToString() + "','" + dataSet.Tables[0].Rows[i]["Qty"].ToString() + "','" + cnv + "','" + dataSet.Tables[0].Rows[i]["Weldments"].ToString() + "'");
						SqlCommand sqlCommand5 = new SqlCommand(cmdText11, sqlConnection);
						sqlCommand5.ExecuteNonQuery();
						if (cnv == 1)
						{
							string cmdText12 = fun.insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,WONo,PId,CId,ItemId,Qty,Weldments", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + CompId + "','" + FinYearId + "','" + SId.ToString() + "','" + text.ToString() + "','" + num2.ToString() + "','" + tPLCId + "','" + dataSet5.Tables[0].Rows[0]["Id"].ToString() + "','" + dataSet.Tables[0].Rows[i]["Qty"].ToString() + "','" + dataSet.Tables[0].Rows[i]["Weldments"].ToString() + "'");
							SqlCommand sqlCommand6 = new SqlCommand(cmdText12, sqlConnection);
							sqlCommand6.ExecuteNonQuery();
							string cmdText13 = fun.update("SD_Cust_WorkOrder_Master", "UpdateWO='1'", "WONo='" + text + "' And  CompId='" + CompId + "' ");
							SqlCommand sqlCommand7 = new SqlCommand(cmdText13, sqlConnection);
							sqlCommand7.ExecuteNonQuery();
						}
					}
				}
			}
			clearTempDb(CompId, SId, text);
			base.Response.Redirect("TPL_Design_WO_TreeView.aspx?WONo=" + text + "&ModId=3&SubModId=23");
		}
		catch (Exception)
		{
		}
	}

	protected void btnproceed_Click(object sender, EventArgs e)
	{
		AddToTPLBOM(0);
	}

	public void clearTempDb(int getCId, string getSId, string getwono)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			con.Open();
			string cmdText = fun.delete("tblDG_TPLItem_Temp", "CompId='" + getCId + "'And SessionId='" + getSId + "'And WONo='" + getwono + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			sqlCommand.ExecuteNonQuery();
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		AddToTPLBOM(1);
	}

	protected void Button1_Click1(object sender, EventArgs e)
	{
		base.Response.Redirect("TPL_Design_WO_TreeView.aspx?WONo=" + wono + "&ModId=3&SubModId=23");
	}

	protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
	{
		string selectedValue = DrpCategory.SelectedValue;
		string selectedValue2 = DrpSubCategory.SelectedValue;
		string selectedValue3 = DrpSearchCode.SelectedValue;
		string text = txtSearchItemCode.Text;
		Fillgridview(selectedValue, selectedValue2, selectedValue3, text);
	}

	protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView4.PageIndex = e.NewPageIndex;
		FillDatagrid();
	}

	protected void DrpSearchCode_SelectedIndexChanged(object sender, EventArgs e)
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
}

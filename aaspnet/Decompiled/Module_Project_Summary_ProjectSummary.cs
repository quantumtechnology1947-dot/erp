using System;
using System.Collections.Generic;
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

public class Module_Project_Summary_ProjectSummary : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string sId = "";

	private int CompId;

	private string CId = "";

	private string Eid = "";

	private string connStr = "";

	private int FinYearId;

	private int h;

	private SqlConnection con;

	protected DropDownList DDLTaskWOType;

	protected DropDownList DropDownList1;

	protected TextBox txtEnqId;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected Button btnSearch;

	protected GridView SearchGridView1;

	protected TabPanel TabPanel1;

	protected DropDownList DDLTaskWOType1;

	protected DropDownList drpfield;

	protected TextBox txtSupplier;

	protected AutoCompleteExtender txtSupplier_AutoCompleteExtender;

	protected TextBox txtPONo;

	protected CheckBox SelectAll;

	protected Button Button1;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Button btnPrint;

	protected TabPanel TabPanel2;

	protected DropDownList DDLTaskWOTypeSH;

	protected DropDownList DropDownList4;

	protected TextBox txtEnqSH;

	protected TextBox TxtSearchSH;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected Button btnSearchSH;

	protected GridView SearchGridView2;

	protected TabPanel TabPanel3;

	protected DropDownList DropDownSupWO;

	protected DropDownList DropDownSup;

	protected TextBox TextSupWONo;

	protected TextBox TextSupCust;

	protected AutoCompleteExtender AutoCompleteExtender12;

	protected Button BtnSup;

	protected GridView GridViewSup;

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
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (!Page.IsPostBack)
			{
				string cmdText = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblSD_WO_Category");
				DDLTaskWOType.DataSource = dataSet.Tables["tblSD_WO_Category"];
				DDLTaskWOType.DataTextField = "Category";
				DDLTaskWOType.DataValueField = "CId";
				DDLTaskWOType.DataBind();
				DDLTaskWOType.Items.Insert(0, "WO Category");
				TxtSearchValue.Visible = false;
				BindDataCust(CId, Eid);
				DDLTaskWOType1.DataSource = dataSet.Tables["tblSD_WO_Category"];
				DDLTaskWOType1.DataTextField = "Category";
				DDLTaskWOType1.DataValueField = "CId";
				DDLTaskWOType1.DataBind();
				DDLTaskWOType1.Items.Insert(0, "WO Category");
				DDLTaskWOTypeSH.DataSource = dataSet.Tables["tblSD_WO_Category"];
				DDLTaskWOTypeSH.DataTextField = "Category";
				DDLTaskWOTypeSH.DataValueField = "CId";
				DDLTaskWOTypeSH.DataBind();
				DDLTaskWOTypeSH.Items.Insert(0, "WO Category");
				DropDownSupWO.DataSource = dataSet.Tables["tblSD_WO_Category"];
				DropDownSupWO.DataTextField = "Category";
				DropDownSupWO.DataValueField = "CId";
				DropDownSupWO.DataBind();
				DropDownSupWO.Items.Insert(0, "WO Category");
				loaddata(h);
				Bindload(CId, Eid);
				BindSup(CId, Eid);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			SearchGridView1.PageIndex = e.NewPageIndex;
			BindDataCust(CId, Eid);
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			BindDataCust(TxtSearchValue.Text, txtEnqId.Text);
		}
		catch (Exception)
		{
		}
	}

	public void BindDataCust(string Cid, string EID)
	{
		try
		{
			Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
			int num2 = Convert.ToInt32(Session["compid"]);
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			new DataTable();
			sqlConnection.Open();
			string value = "";
			if (DropDownList1.SelectedValue == "1" && txtEnqId.Text != "")
			{
				value = " AND SD_Cust_WorkOrder_Master.EnqId='" + txtEnqId.Text + "'";
			}
			if (DropDownList1.SelectedValue == "2" && txtEnqId.Text != "")
			{
				value = " AND SD_Cust_WorkOrder_Master.PONo='" + txtEnqId.Text + "'";
			}
			if (DropDownList1.SelectedValue == "3" && txtEnqId.Text != "")
			{
				value = " AND SD_Cust_WorkOrder_Master.WONo='" + txtEnqId.Text + "'";
			}
			string value2 = "";
			if (DropDownList1.SelectedValue == "0" && TxtSearchValue.Text != "")
			{
				string code = fun.getCode(TxtSearchValue.Text);
				value2 = " AND SD_Cust_WorkOrder_Master.CustomerId='" + code + "'";
			}
			string value3 = "";
			if (DDLTaskWOType.SelectedValue != "WO Category")
			{
				value3 = " AND SD_Cust_WorkOrder_Master.CId='" + Convert.ToInt32(DDLTaskWOType.SelectedValue) + "'";
			}
			string value4 = " ";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_WONO_NotInBom", sqlConnection);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = num2;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = num;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = value;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@y"].Value = value2;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@z", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@z"].Value = value3;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@l", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@l"].Value = value4;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			SearchGridView1.DataSource = dataSet;
			SearchGridView1.DataBind();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DropDownList1.SelectedValue == "0")
			{
				txtEnqId.Visible = false;
				TxtSearchValue.Visible = true;
				TxtSearchValue.Text = "";
				BindDataCust(CId, Eid);
			}
			if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "Select")
			{
				txtEnqId.Visible = true;
				TxtSearchValue.Visible = false;
				txtEnqId.Text = "";
				BindDataCust(CId, Eid);
			}
		}
		catch (Exception)
		{
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
		string selectCommandText = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
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

	protected void SearchGridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			if (e.CommandName == "NavigateTo")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				empty = ((LinkButton)gridViewRow.FindControl("BtnWONo")).Text;
				empty2 = ((DropDownList)gridViewRow.FindControl("DropDownList2")).SelectedValue;
				if (empty != string.Empty && empty2 != string.Empty && empty2 == "2")
				{
					base.Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary_Details_Grid.aspx?WONo=" + empty + "&SwitchTo=" + empty2 + "&ModId=&SubModId=");
				}
				else if (empty != string.Empty && empty2 != string.Empty && empty2 == "1")
				{
					base.Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary_Details_Bought.aspx?WONo=" + empty + "&SwitchTo=" + empty2 + "&ModId=&SubModId=");
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DDLTaskWOType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DDLTaskWOType.SelectedValue != "WO Category")
		{
			BindDataCust(CId, Eid);
		}
		else
		{
			BindDataCust(CId, Eid);
		}
	}

	public void loaddata(int c)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			string value = "";
			if (drpfield.SelectedValue == "0" && txtSupplier.Text != "")
			{
				string code = fun.getCode(txtSupplier.Text);
				value = " AND SD_Cust_WorkOrder_Master.CustomerId='" + code + "'";
			}
			string value2 = "";
			if (drpfield.SelectedValue == "1" && txtPONo.Text != "")
			{
				value2 = " AND SD_Cust_WorkOrder_Master.WONo='" + txtPONo.Text + "'";
			}
			if (drpfield.SelectedValue == "2" && txtPONo.Text != "")
			{
				value2 = " AND SD_Cust_WorkOrder_Master.TaskProjectTitle Like '%" + txtPONo.Text + "%'";
			}
			string value3 = "";
			if (DDLTaskWOType1.SelectedValue != "WO Category")
			{
				value3 = " AND SD_Cust_WorkOrder_Master.CId='" + Convert.ToInt32(DDLTaskWOType1.SelectedValue) + "'";
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_ForeCast", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = FinYearId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = value;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@y"].Value = value2;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@z", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@z"].Value = value3;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void DDLTaskWOType1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DDLTaskWOType1.SelectedValue != "WO Category")
		{
			int c = Convert.ToInt32(DDLTaskWOType1.SelectedValue);
			loaddata(c);
		}
		else
		{
			loaddata(h);
		}
	}

	protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (drpfield.SelectedValue == "0")
			{
				txtPONo.Visible = false;
				txtSupplier.Visible = true;
				txtSupplier.Text = "";
				loaddata(h);
			}
			if (drpfield.SelectedValue == "1" || drpfield.SelectedValue == "2")
			{
				txtPONo.Visible = true;
				txtPONo.Text = "";
				txtSupplier.Visible = false;
				loaddata(h);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void SelectAll_CheckedChanged(object sender, EventArgs e)
	{
		if (SelectAll.Checked)
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				((CheckBox)row.FindControl("CheckBox1")).Checked = true;
			}
		}
		if (SelectAll.Checked)
		{
			return;
		}
		foreach (GridViewRow row2 in GridView1.Rows)
		{
			((CheckBox)row2.FindControl("CheckBox1")).Checked = false;
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		loaddata(h);
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
		string selectCommandText = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
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

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		loaddata(h);
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		_ = TabContainer1.ActiveTabIndex;
		_ = 1;
	}

	protected void Button2_Click1(object sender, EventArgs e)
	{
	}

	protected void btnPrint_Click(object sender, EventArgs e)
	{
		try
		{
			List<string> list = new List<string>();
			string text = string.Empty;
			_ = string.Empty;
			_ = string.Empty;
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					list.Add(Convert.ToString(((Label)row.FindControl("lblWONo")).Text + ","));
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				text += list[i].ToString();
			}
			Session["Wono"] = text;
			if (Session["Wono"] != null && !string.IsNullOrEmpty(Session["Wono"].ToString()))
			{
				base.Response.Redirect("ProjectSummary_WONo.aspx?ModId=7");
				return;
			}
			string empty = string.Empty;
			empty = "Select Workorder.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
		catch (Exception)
		{
		}
	}

	public void Bindload(string Cid, string EID)
	{
		try
		{
			Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
			int num2 = Convert.ToInt32(Session["compid"]);
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			new DataTable();
			sqlConnection.Open();
			string value = "";
			if (DropDownList4.SelectedValue == "1" && txtEnqSH.Text != "")
			{
				value = " AND SD_Cust_WorkOrder_Master.EnqId='" + txtEnqSH.Text + "'";
			}
			if (DropDownList4.SelectedValue == "2" && txtEnqSH.Text != "")
			{
				value = " AND SD_Cust_WorkOrder_Master.PONo='" + txtEnqSH.Text + "'";
			}
			if (DropDownList4.SelectedValue == "3" && txtEnqSH.Text != "")
			{
				value = " AND SD_Cust_WorkOrder_Master.WONo='" + txtEnqSH.Text + "'";
			}
			string value2 = "";
			if (DropDownList4.SelectedValue == "0" && TxtSearchSH.Text != "")
			{
				string code = fun.getCode(TxtSearchSH.Text);
				value2 = " AND SD_Cust_WorkOrder_Master.CustomerId='" + code + "'";
			}
			string value3 = "";
			if (DDLTaskWOTypeSH.SelectedValue != "WO Category")
			{
				value3 = " AND SD_Cust_WorkOrder_Master.CId='" + Convert.ToInt32(DDLTaskWOTypeSH.SelectedValue) + "'";
			}
			string value4 = " ";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_WONO_NotInBom", sqlConnection);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = num2;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = num;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = value;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@y"].Value = value2;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@z", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@z"].Value = value3;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@l", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@l"].Value = value4;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			SearchGridView2.DataSource = dataSet;
			SearchGridView2.DataBind();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void SearchGridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			SearchGridView2.PageIndex = e.NewPageIndex;
			Bindload(CId, Eid);
		}
		catch (Exception)
		{
		}
	}

	protected void SearchGridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			if (e.CommandName == "NavigateToSH")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				empty = ((LinkButton)gridViewRow.FindControl("BtnWONoSH")).Text;
				empty2 = ((DropDownList)gridViewRow.FindControl("DropDownListSH")).SelectedValue;
				if (empty != string.Empty && empty2 != string.Empty && empty2 == "2")
				{
					base.Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary_Shortage_M.aspx?WONo=" + empty + "&SwitchTo=" + empty2 + "&ModId=&SubModId=");
				}
				else if (empty != string.Empty && empty2 != string.Empty && empty2 == "1")
				{
					base.Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary_Shortage_B.aspx?WONo=" + empty + "&SwitchTo=" + empty2 + "&ModId=&SubModId=");
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearchSH_Click(object sender, EventArgs e)
	{
		try
		{
			Bindload(TxtSearchSH.Text, txtEnqSH.Text);
		}
		catch (Exception)
		{
		}
	}

	protected void DDLTaskWOTypeSH_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DDLTaskWOTypeSH.SelectedValue != "WO Category")
		{
			Bindload(CId, Eid);
		}
		else
		{
			Bindload(CId, Eid);
		}
	}

	protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DropDownList4.SelectedValue == "0")
			{
				txtEnqSH.Visible = false;
				TxtSearchSH.Visible = true;
				TxtSearchSH.Text = "";
				Bindload(CId, Eid);
			}
			if (DropDownList4.SelectedValue == "1" || DropDownList4.SelectedValue == "2" || DropDownList4.SelectedValue == "3" || DropDownList4.SelectedValue == "Select")
			{
				txtEnqSH.Visible = true;
				TxtSearchSH.Visible = false;
				txtEnqSH.Text = "";
				Bindload(CId, Eid);
			}
		}
		catch (Exception)
		{
		}
	}

	public void BindSup(string Cid, string EID)
	{
		try
		{
			Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
			int num2 = Convert.ToInt32(Session["compid"]);
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			new DataTable();
			sqlConnection.Open();
			string value = "";
			if (DropDownSup.SelectedValue == "1" && TextSupWONo.Text != "")
			{
				value = " AND SD_Cust_WorkOrder_Master.EnqId='" + TextSupWONo.Text + "'";
			}
			if (DropDownSup.SelectedValue == "2" && TextSupWONo.Text != "")
			{
				value = " AND SD_Cust_WorkOrder_Master.PONo='" + TextSupWONo.Text + "'";
			}
			if (DropDownSup.SelectedValue == "3" && TextSupWONo.Text != "")
			{
				value = " AND SD_Cust_WorkOrder_Master.WONo='" + TextSupWONo.Text + "'";
			}
			string value2 = "";
			if (DropDownSup.SelectedValue == "0" && TextSupCust.Text != "")
			{
				string code = fun.getCode(TextSupCust.Text);
				value2 = " AND SD_Cust_WorkOrder_Master.CustomerId='" + code + "'";
			}
			string value3 = "";
			if (DropDownSupWO.SelectedValue != "WO Category")
			{
				value3 = " AND SD_Cust_WorkOrder_Master.CId='" + Convert.ToInt32(DropDownSupWO.SelectedValue) + "'";
			}
			string value4 = " ";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_WONO_NotInBom", sqlConnection);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = num2;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = num;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = value;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@y"].Value = value2;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@z", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@z"].Value = value3;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@l", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@l"].Value = value4;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridViewSup.DataSource = dataSet;
			GridViewSup.DataBind();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridViewSup_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridViewSup.PageIndex = e.NewPageIndex;
			BindSup(CId, Eid);
		}
		catch (Exception)
		{
		}
	}

	protected void GridViewSup_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			if (e.CommandName == "Sup")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				empty = ((LinkButton)gridViewRow.FindControl("BtnWONoSup")).Text;
				empty2 = ((DropDownList)gridViewRow.FindControl("DropDownSuptype")).SelectedValue;
				base.Response.Write("heloo");
				if (empty != string.Empty && empty2 != string.Empty && empty2 == "2")
				{
					base.Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary_Sup_M.aspx?WONo=" + empty + "&SwitchTo=" + empty2 + "&ModId=&SubModId=");
				}
				else if (empty != string.Empty && empty2 != string.Empty && empty2 == "1")
				{
					base.Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary_Sup_B.aspx?WONo=" + empty + "&SwitchTo=" + empty2 + "&ModId=&SubModId=");
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnSup_Click(object sender, EventArgs e)
	{
		try
		{
			BindSup(TextSupWONo.Text, TextSupCust.Text);
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownSupWO_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DropDownSupWO.SelectedValue != "WO Category")
		{
			BindSup(CId, Eid);
		}
		else
		{
			BindSup(CId, Eid);
		}
	}

	protected void DropDownSup_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DropDownSup.SelectedValue == "0")
			{
				TextSupWONo.Visible = false;
				TextSupCust.Visible = true;
				TextSupCust.Text = "";
				BindSup(CId, Eid);
			}
			if (DropDownSup.SelectedValue == "1" || DropDownSup.SelectedValue == "2" || DropDownSup.SelectedValue == "3" || DropDownSup.SelectedValue == "Select")
			{
				TextSupWONo.Visible = true;
				TextSupCust.Visible = false;
				TextSupWONo.Text = "";
				BindSup(CId, Eid);
			}
		}
		catch (Exception)
		{
		}
	}
}

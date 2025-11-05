using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Transactions_CustomerChallan_New_Details : Page, IRequiresSessionState
{
	protected DropDownList DrpType;

	protected DropDownList DrpCategory;

	protected DropDownList DrpSearchCode;

	protected DropDownList DropDownList3;

	protected TextBox txtSearchItemCode;

	protected Button btnSearch;

	protected GridView GridView2;

	protected Panel Panel2;

	protected Button BtnAdd;

	protected Button Btncancel;

	protected Panel Panel1;

	protected TabPanel Add;

	protected HtmlGenericControl myframe;

	protected Button Btncancel1;

	protected Panel Panel3;

	protected TabPanel View;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private string CDate = "";

	private string CTime = "";

	private string custid = "";

	private string wono = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			wono = base.Request.QueryString["WONo"].ToString();
			string cmdText = fun.select("CustomerId", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "'  And WONo='" + wono + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			custid = dataSet.Tables[0].Rows[0]["CustomerId"].ToString();
			if (!base.IsPostBack)
			{
				DrpCategory.Items.Clear();
				DrpCategory.Items.Insert(0, "Select");
				DropDownList3.Visible = false;
				DrpCategory.Visible = false;
				DrpSearchCode.Visible = false;
				txtSearchItemCode.Visible = false;
			}
			myframe.Attributes.Add("Src", "CustomerChallan_Clear.aspx?WONO=" + wono + "&ModId=9&SubModId=");
		}
		catch (Exception)
		{
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
				GetValidate();
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

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		GetValidate();
	}

	protected void BtnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					num2++;
					if (((CheckBox)row.FindControl("CheckBox1")).Checked && ((TextBox)row.FindControl("TxtQty")).Text != "" && fun.NumberValidationQty(((TextBox)row.FindControl("TxtQty")).Text) && Convert.ToDouble(((TextBox)row.FindControl("TxtQty")).Text) != 0.0)
					{
						Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TxtQty")).Text).ToString("N3"));
						num++;
					}
				}
			}
			if (num2 == num && num > 0)
			{
				DataSet dataSet = new DataSet();
				string cmdText = fun.select("CCNo", "tblInv_Customer_Challan_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblInv_Supplier_Challan_Master");
				string text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
				int num4 = fun.chkEmpCustSupplierCode(custid, 2, CompId);
				if (num4 == 1)
				{
					string cmdText2 = fun.insert("tblInv_Customer_Challan_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CCNo,CustomerId,WONo", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text + "','" + custid + "','" + wono + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					string cmdText3 = fun.select("Id", "tblInv_Customer_Challan_Master", "CompId='" + CompId + "'  Order By Id Desc");
					SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					int num5 = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Id"].ToString());
					foreach (GridViewRow row2 in GridView2.Rows)
					{
						if (((CheckBox)row2.FindControl("CheckBox1")).Checked && ((TextBox)row2.FindControl("TxtQty")).Text != "" && fun.NumberValidationQty(((TextBox)row2.FindControl("TxtQty")).Text) && Convert.ToDouble(((TextBox)row2.FindControl("TxtQty")).Text) != 0.0)
						{
							int num6 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
							double num7 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("TxtQty")).Text).ToString("N3"));
							SqlCommand sqlCommand2 = new SqlCommand(fun.insert("tblInv_Customer_Challan_Details", "MId,ChallanQty,ItemId", num5 + ",'" + num7 + "','" + num6 + "'"), con);
							con.Open();
							sqlCommand2.ExecuteNonQuery();
							con.Close();
							num3++;
						}
					}
				}
			}
			else
			{
				string empty = string.Empty;
				empty = "Invalid input data.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
			if (num3 > 0)
			{
				string selectedValue = DrpCategory.SelectedValue;
				string selectedValue2 = DrpSearchCode.SelectedValue;
				string text2 = txtSearchItemCode.Text;
				string selectedValue3 = DrpType.SelectedValue;
				Fillgrid(selectedValue, selectedValue2, text2, selectedValue3);
			}
		}
		catch (Exception)
		{
		}
	}

	public void GetValidate()
	{
		try
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					((RequiredFieldValidator)row.FindControl("ReqChNo")).Visible = true;
					((TextBox)row.FindControl("TxtQty")).Enabled = true;
				}
				else
				{
					((RequiredFieldValidator)row.FindControl("ReqChNo")).Visible = false;
					((TextBox)row.FindControl("TxtQty")).Enabled = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CustomerChallan_New.aspx?ModId=9&SubModId=121");
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
	}

	protected void Btncancel1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CustomerChallan_New.aspx?ModId=9&SubModId=121");
	}
}

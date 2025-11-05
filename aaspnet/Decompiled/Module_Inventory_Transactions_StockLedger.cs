using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Transactions_StockLedger : Page, IRequiresSessionState
{
	protected Label lblFromDate;

	protected Label lblToDate;

	protected TextBox TxtFromDate;

	protected CalendarExtender TxtFromDate_CalendarExtender;

	protected RequiredFieldValidator ReqFromDt;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected TextBox TxtToDate;

	protected CalendarExtender TxtToDate_CalendarExtender;

	protected RequiredFieldValidator ReqCate2;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected Label lblMessage;

	protected DropDownList DrpType;

	protected DropDownList DrpCategory1;

	protected DropDownList DrpSearchCode;

	protected DropDownList DropDownList3;

	protected TextBox txtSearchItemCode;

	protected Button Btnsearch;

	protected GridView GridView1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private DataSet DS = new DataSet();

	private string fd1 = "";

	private string td1 = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			lblMessage.Text = "";
			TxtFromDate.Attributes.Add("readonly", "readonly");
			TxtToDate.Attributes.Add("readonly", "readonly");
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = fun.select("FinYearFrom,FinYearTo", "tblFinancial_master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				fd1 = fun.FromDateDMY(dataSet.Tables[0].Rows[0][0].ToString());
				td1 = fun.FromDateDMY(dataSet.Tables[0].Rows[0][1].ToString());
			}
			if (!base.IsPostBack)
			{
				lblFromDate.Text = fd1;
				TxtFromDate.Text = fd1;
				TxtToDate.Text = fun.FromDateDMY(fun.getCurrDate());
				lblToDate.Text = td1;
				DrpCategory1.Items.Clear();
				DrpCategory1.Items.Insert(0, "Select");
				DropDownList3.Visible = false;
				DrpCategory1.Visible = false;
				DrpSearchCode.Visible = false;
				txtSearchItemCode.Visible = false;
				string cmdText2 = fun.select("CId,'['+Symbol+'] - '+CName as Category", "tblDG_Category_Master", "CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(DS, "tblDG_Category_Master");
				DrpCategory1.DataSource = DS.Tables["tblDG_Category_Master"];
				DrpCategory1.DataTextField = "Category";
				DrpCategory1.DataValueField = "CId";
				DrpCategory1.DataBind();
				DrpCategory1.Items.Insert(0, "Select");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		string selectedValue = DrpCategory1.SelectedValue;
		string selectedValue2 = DrpSearchCode.SelectedValue;
		string text = txtSearchItemCode.Text;
		string selectedValue3 = DrpType.SelectedValue;
		Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
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
								value2 = " And tblDG_Item_Master.ManfDesc Like '" + s + "%'";
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
				GridView1.DataSource = dataSet;
				GridView1.DataBind();
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

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblId")).Text;
				_ = ((Label)gridViewRow.FindControl("itemcode")).Text;
				_ = ((Label)gridViewRow.FindControl("manfdesc")).Text;
				_ = ((Label)gridViewRow.FindControl("uomBasic")).Text;
				string text2 = TxtFromDate.Text;
				string text3 = TxtToDate.Text;
				if (Convert.ToDateTime(fun.FromDate(TxtToDate.Text)) >= Convert.ToDateTime(fun.FromDate(TxtFromDate.Text)) && fun.DateValidation(TxtFromDate.Text) && fun.DateValidation(TxtToDate.Text))
				{
					if (Convert.ToDateTime(fun.FromDate(fd1)) <= Convert.ToDateTime(fun.FromDate(text2)))
					{
						base.Response.Redirect("StockLedger_Details.aspx?Id=" + text + "&FD=" + text2 + "&TD=" + text3);
					}
					else
					{
						lblMessage.Text = "From date should not be Less than Opening Date!";
					}
				}
				else
				{
					lblMessage.Text = "From date should be Less than or Equal to To Opening Date!";
				}
			}
			if (e.CommandName == "downloadImg")
			{
				foreach (GridViewRow row in GridView1.Rows)
				{
					int num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType");
				}
			}
			if (!(e.CommandName == "downloadSpec"))
			{
				return;
			}
			foreach (GridViewRow row2 in GridView1.Rows)
			{
				int num2 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
				base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num2 + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Btnsearch_Click(object sender, EventArgs e)
	{
		try
		{
			if (DrpType.SelectedValue != "Select")
			{
				string selectedValue = DrpCategory1.SelectedValue;
				string selectedValue2 = DrpSearchCode.SelectedValue;
				string text = txtSearchItemCode.Text;
				string selectedValue3 = DrpType.SelectedValue;
				Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
			}
			else
			{
				string empty = string.Empty;
				empty = "Select Category or WO Items.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Drp1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string selectedValue = DrpCategory1.SelectedValue;
		string selectedValue2 = DrpSearchCode.SelectedValue;
		string text = txtSearchItemCode.Text;
		string selectedValue3 = DrpType.SelectedValue;
		Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
	}

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
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
				string cmdText = fun.select("CId,Symbol+'-'+CName as Category", "tblDG_Category_Master", "CompId='" + CompId + "'");
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
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				break;
			}
		}
		catch (Exception)
		{
		}
	}
}

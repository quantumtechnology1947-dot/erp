using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_CustomerChallan_New_Details_Items : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string sId = "";

	private int CompId;

	private int FinYearId;

	protected DropDownList DrpType;

	protected DropDownList DrpCategory;

	protected DropDownList DrpSearchCode;

	protected DropDownList DropDownList3;

	protected TextBox txtSearchItemCode;

	protected Button btnSearch;

	protected GridView GridView2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		CompId = Convert.ToInt32(Session["compid"]);
		sId = Session["username"].ToString();
		FinYearId = Convert.ToInt32(Session["finyear"]);
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		if (!base.IsPostBack)
		{
			DrpCategory.Items.Clear();
			DrpCategory.Items.Insert(0, "Select");
			DropDownList3.Visible = false;
			DrpCategory.Visible = false;
			DrpSearchCode.Visible = false;
			txtSearchItemCode.Visible = false;
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
}

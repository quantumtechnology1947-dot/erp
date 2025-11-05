using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Masters_RateSet : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private DataSet DS2 = new DataSet();

	private int CompId;

	private int FinYearId;

	private string MSG = "";

	protected DropDownList DrpType;

	protected DropDownList DrpCategory1;

	protected DropDownList DrpSearchCode;

	protected DropDownList DropDownList3;

	protected TextBox txtSearchItemCode;

	protected Button btnSearch;

	protected GridView GridView2;

	protected Panel Panel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (!base.IsPostBack)
			{
				DrpCategory1.Items.Clear();
				DrpCategory1.Items.Insert(0, "Select");
				DropDownList3.Visible = false;
				DrpCategory1.Visible = false;
				DrpSearchCode.Visible = false;
				txtSearchItemCode.Visible = false;
			}
		}
		catch (Exception)
		{
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

	protected void DrpSearchCode_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DrpSearchCode.SelectedItem.Text == "Location")
		{
			DropDownList3.Visible = true;
			txtSearchItemCode.Visible = false;
			string selectedValue = DrpCategory1.SelectedValue;
			string selectedValue2 = DrpSearchCode.SelectedValue;
			string text = txtSearchItemCode.Text;
			string selectedValue3 = DrpType.SelectedValue;
			Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
		}
		else
		{
			DropDownList3.Visible = false;
			txtSearchItemCode.Visible = true;
			string selectedValue4 = DrpCategory1.SelectedValue;
			string selectedValue5 = DrpSearchCode.SelectedValue;
			string text2 = txtSearchItemCode.Text;
			string selectedValue6 = DrpType.SelectedValue;
			Fillgrid(selectedValue4, selectedValue5, text2, selectedValue6);
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "sel")
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblId")).Text;
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			base.Response.Redirect("~/Module/MaterialManagement/Masters/RateSet_details.aspx?ModId=6&SubModId=139&ItemId=" + text + "&Key=" + randomAlphaNumeric);
		}
	}
}

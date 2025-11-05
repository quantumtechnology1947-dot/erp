using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Machinery_Transactions_PMBM_Print : Page, IRequiresSessionState
{
	protected DropDownList DrpCategory;

	protected DropDownList DrpSubCategory;

	protected DropDownList DrpSearchCode;

	protected TextBox txtSearchItemCode;

	protected Button btnSearch;

	protected GridView GridView2;

	protected GridView GridView1;

	protected UpdatePanel Up;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string sId = "";

	private int CompId;

	private int FinYearId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (!base.IsPostBack)
			{
				fun.drpDesignCategory(DrpCategory, DrpSubCategory);
			}
			string selectedValue = DrpCategory.SelectedValue;
			string selectedValue2 = DrpSubCategory.SelectedValue;
			string selectedValue3 = DrpSearchCode.SelectedValue;
			string text = txtSearchItemCode.Text;
			Fillgridview(selectedValue, selectedValue2, selectedValue3, text);
			Up.Visible = true;
		}
		catch (Exception)
		{
		}
	}

	public void Fillgridview(string sd, string A, string B, string s)
	{
		try
		{
			string text = "";
			string text2 = "";
			if (sd != "Select Category")
			{
				string text3 = "";
				if (A != "Select SubCategory")
				{
					text3 = "  And tblDG_Item_Master.SCId='" + A + "'";
				}
				text2 = " AND  tblDG_Item_Master.CId='" + sd + "'";
				string text4 = "";
				txtSearchItemCode.Visible = true;
				if (B != "Select")
				{
					if (B == "tblDG_Item_Master.ItemCode")
					{
						txtSearchItemCode.Visible = true;
						text4 = " And tblDG_Item_Master.ItemCode Like '" + s + "%'";
					}
					if (B == "tblDG_Item_Master.ManfDesc")
					{
						txtSearchItemCode.Visible = true;
						text4 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
					}
				}
				text = fun.select("tblMS_Master.SysDate As LastPMBMDate,tblMS_Master.Id As MSId,tblDG_Item_Master.Id,SUBSTRING(tblDG_Item_Master.ManfDesc,0,80)+'...' AS ManfDesc ,tblDG_Item_Master.StockQty, tblDG_Item_Master.ItemCode,tblDG_Item_Master.Location,tblDG_Item_Master.UOMBasic", " tblDG_Category_Master,tblDG_Item_Master,tblMS_Master", " tblDG_Item_Master.CId=tblDG_Category_Master.CId " + text2 + text3 + text4 + " AND tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.Absolute!='1' And tblMS_Master.ItemId=tblDG_Item_Master.Id Order By tblDG_Item_Master.Id Desc ");
			}
			else
			{
				text = fun.select("tblMS_Master.SysDate As LastPMBMDate, tblMS_Master.Id As MSId,tblDG_Item_Master.Id,SUBSTRING(tblDG_Item_Master.ManfDesc,0,80)+'...' AS ManfDesc ,tblDG_Item_Master.StockQty, tblDG_Item_Master.ItemCode,tblDG_Item_Master.Location,tblDG_Item_Master.UOMBasic", "tblDG_Category_Master,tblDG_Item_Master,tblMS_Master", "tblDG_Item_Master.CId=tblDG_Category_Master.CId AND tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.Absolute!='1'And tblMS_Master.ItemId=tblDG_Item_Master.Id Order By tblDG_Item_Master.Id Desc");
			}
			fillGrid(text, GridView2);
		}
		catch (Exception)
		{
		}
	}

	public void fillGrid(string sql, GridView GridView2)
	{
		string connectionString = fun.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			SqlCommand selectCommand = new SqlCommand(sql, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Id", typeof(string));
			dataTable.Columns.Add("ItemCode", typeof(string));
			dataTable.Columns.Add("ManfDesc", typeof(string));
			dataTable.Columns.Add("LastPMBMDate", typeof(string));
			dataTable.Columns.Add("MSId", typeof(string));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
				dataRow[3] = dataSet.Tables[0].Rows[i]["LastPMBMDate"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["MSId"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = 0;
				num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblMSId")).Text);
				int num2 = 0;
				num2 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				ViewState["MSId"] = num;
				ViewState["Id"] = num2;
				PMBMGrid();
			}
		}
		catch (Exception)
		{
		}
	}

	public void PMBMGrid()
	{
		try
		{
			if (!string.IsNullOrEmpty(ViewState["Id"].ToString()))
			{
				Convert.ToInt32(ViewState["Id"]);
			}
			int num = 0;
			if (!string.IsNullOrEmpty(ViewState["MSId"].ToString()))
			{
				num = Convert.ToInt32(ViewState["MSId"]);
			}
			string cmdText = fun.select("*", "tblMS_PMBM_Master", " MachineId='" + num + "' AND CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Id", typeof(int));
			dataTable.Columns.Add("PMBMDate", typeof(string));
			dataTable.Columns.Add("type", typeof(string));
			dataTable.Columns.Add("AgencyName", typeof(string));
			dataTable.Columns.Add("EngName", typeof(string));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				if (dataSet.Tables[0].Rows[i]["PMBM"].ToString() == "0")
				{
					dataRow[2] = "Preventive";
				}
				else
				{
					dataRow[2] = "Breakdown";
				}
				dataRow[3] = dataSet.Tables[0].Rows[i]["NameOfAgency"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["NameOfEngineer"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DrpCategory.SelectedValue != "Select Category")
			{
				SqlCommand selectCommand = new SqlCommand(fun.select(" CId,SCId,Symbol+' - '+SCName As SubCatName ", "tblDG_SubCategory_Master ", " CId=" + DrpCategory.SelectedValue), con);
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
				DrpSubCategory.SelectedIndex = 0;
				DrpSearchCode.SelectedIndex = 0;
				txtSearchItemCode.Text = "";
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
			DrpSearchCode.SelectedValue = "Select";
			Up.Visible = false;
		}
	}

	protected void DrpSubCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string selectedValue = DrpCategory.SelectedValue;
			string selectedValue2 = DrpSubCategory.SelectedValue;
			string selectedValue3 = DrpSearchCode.SelectedValue;
			string text = txtSearchItemCode.Text;
			Fillgridview(selectedValue, selectedValue2, selectedValue3, text);
			Up.Visible = false;
		}
		catch (Exception)
		{
		}
		finally
		{
			DrpSearchCode.SelectedValue = "Select";
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
			Up.Visible = false;
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
			string selectedValue2 = DrpSubCategory.SelectedValue;
			string selectedValue3 = DrpSearchCode.SelectedValue;
			string text = txtSearchItemCode.Text;
			Fillgridview(selectedValue, selectedValue2, selectedValue3, text);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		PMBMGrid();
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = 0;
				num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				if (num != 0)
				{
					string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
					base.Response.Redirect("~/Module/Machinery/Transactions/PMBM_Print_Details.aspx?PMBMId=" + num + "&Key=" + randomAlphaNumeric + "&ModId=15&SubModId=68");
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpSearchCode_SelectedIndexChanged(object sender, EventArgs e)
	{
		Up.Visible = false;
	}
}

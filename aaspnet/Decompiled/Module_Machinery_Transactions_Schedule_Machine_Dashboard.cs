using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Machinery_Transactions_Schedule_Machine_Dashboard : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string sId = "";

	private int CompId;

	private int FinYearId;

	protected DropDownList DrpCategory;

	protected DropDownList DrpSubCategory;

	protected DropDownList DrpSearchCode;

	protected TextBox txtSearchItemCode;

	protected Button btnSearch;

	protected GridView GridView2;

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
				text = fun.select("tblDG_Item_Master.Id,SUBSTRING(tblDG_Item_Master.ManfDesc,0,80)+'...' AS ManfDesc , tblDG_Item_Master.ItemCode,tblMS_Master.Id As MachineId,tblMS_Master.SysDate,tblMS_Master.Make,tblMS_Master.Model,tblMS_Master.Capacity,tblMS_Master.Location,tblMS_Master.PMDays", " tblDG_Category_Master,tblDG_Item_Master,tblMS_Master", " tblDG_Item_Master.CId=tblDG_Category_Master.CId " + text2 + text3 + text4 + " AND tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.Absolute!='1' And tblMS_Master.ItemId=tblDG_Item_Master.Id Order By tblDG_Item_Master.Id Desc ");
			}
			else
			{
				text = fun.select("tblDG_Item_Master.Id,SUBSTRING(tblDG_Item_Master.ManfDesc,0,80)+'...' AS ManfDesc , tblDG_Item_Master.ItemCode,tblMS_Master.Id As MachineId,tblMS_Master.SysDate,tblMS_Master.Make,tblMS_Master.Model,tblMS_Master.Capacity,tblMS_Master.Location,tblMS_Master.PMDays", "tblDG_Category_Master,tblDG_Item_Master,tblMS_Master", "tblDG_Item_Master.CId=tblDG_Category_Master.CId AND tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.Absolute!='1'And tblMS_Master.ItemId=tblDG_Item_Master.Id Order By tblDG_Item_Master.Id Desc");
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
			dataTable.Columns.Add("Id", typeof(int));
			dataTable.Columns.Add("ItemCode", typeof(string));
			dataTable.Columns.Add("ManfDesc", typeof(string));
			dataTable.Columns.Add("Make", typeof(string));
			dataTable.Columns.Add("Model", typeof(string));
			dataTable.Columns.Add("Location", typeof(string));
			dataTable.Columns.Add("Capacity", typeof(string));
			dataTable.Columns.Add("MachineId", typeof(int));
			dataTable.Columns.Add("SysDate", typeof(string));
			dataTable.Columns.Add("PMDate", typeof(string));
			dataTable.Columns.Add("RemainDay", typeof(int));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
				dataRow[1] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
				dataRow[3] = dataSet.Tables[0].Rows[i]["Make"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["Model"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["Location"].ToString();
				dataRow[6] = dataSet.Tables[0].Rows[i]["Capacity"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["MachineId"].ToString();
				dataRow[8] = fun.FromDate(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				string cmdText = fun.select("SysDate,MachineId", "tblMS_PMBM_Master", "MachineId='" + dataSet.Tables[0].Rows[i]["MachineId"].ToString() + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				TimeSpan timeSpan = default(TimeSpan);
				string currDate = fun.getCurrDate();
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					timeSpan = Convert.ToDateTime(currDate) - Convert.ToDateTime(dataSet2.Tables[0].Rows[0]["SysDate"].ToString());
					dataRow[9] = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["SysDate"].ToString());
				}
				else
				{
					timeSpan = Convert.ToDateTime(currDate) - Convert.ToDateTime(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				}
				dataRow[10] = ((double)Convert.ToInt32(dataSet.Tables[0].Rows[i]["PMDays"]) - timeSpan.TotalDays).ToString();
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
				num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				if (num != 0)
				{
					base.Response.Redirect("~/Module/Machinery/Transactions/Schedule_Process_Dashboard.aspx?Id=" + num + "&ModId=15&SubModId=70");
				}
			}
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
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Machinery_Transactions_PMBM_New : Page, IRequiresSessionState
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
			string cmdText = "delete from tblMS_Spares_Temp";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			string cmdText2 = "delete from tblMS_Process_Temp";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
			con.Open();
			sqlCommand2.ExecuteNonQuery();
			con.Close();
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
				text = fun.select(" tblMS_Master.PMDays,tblMS_Master.SysDate,tblMS_Master.Id As MId,tblDG_Item_Master.Id,SUBSTRING(tblDG_Item_Master.ManfDesc,0,80)+'...' AS ManfDesc ,tblDG_Item_Master.StockQty, tblDG_Item_Master.ItemCode,tblDG_Item_Master.Location,tblDG_Item_Master.UOMBasic", " tblDG_Category_Master,tblDG_Item_Master,tblMS_Master", " tblDG_Item_Master.CId=tblDG_Category_Master.CId " + text2 + text3 + text4 + " AND tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.Absolute!='1' And tblMS_Master.ItemId=tblDG_Item_Master.Id Order By tblDG_Item_Master.Id Desc ");
			}
			else
			{
				text = fun.select("tblMS_Master.PMDays,tblMS_Master.SysDate, tblMS_Master.Id As MId,tblDG_Item_Master.Id,tblDG_Item_Master.Id,SUBSTRING(tblDG_Item_Master.ManfDesc,0,80)+'...' AS ManfDesc ,tblDG_Item_Master.StockQty, tblDG_Item_Master.ItemCode,tblDG_Item_Master.Location,tblDG_Item_Master.UOMBasic", "tblDG_Category_Master,tblDG_Item_Master,tblMS_Master", "tblDG_Item_Master.CId=tblDG_Category_Master.CId AND tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.Absolute!='1'And tblMS_Master.ItemId=tblDG_Item_Master.Id Order By tblDG_Item_Master.Id Desc");
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
			dataTable.Columns.Add("UOMBasic", typeof(string));
			dataTable.Columns.Add("Location", typeof(string));
			dataTable.Columns.Add("Qty", typeof(string));
			dataTable.Columns.Add("PMDays", typeof(string));
			dataTable.Columns.Add("SysDate", typeof(string));
			dataTable.Columns.Add("RemainDays", typeof(string));
			dataTable.Columns.Add("MId", typeof(string));
			dataTable.Columns.Add("LastPMBMDate", typeof(string));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
				string cmdText = fun.select("Symbol ", "Unit_Master", "Id='" + dataSet.Tables[0].Rows[i]["UOMBasic"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[3] = dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
				}
				string cmdText2 = fun.select("Location,PMDays,SysDate", " tblMS_Master ", string.Concat(" ItemId='", dataSet.Tables[0].Rows[i]["Id"], "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[4] = dataSet3.Tables[0].Rows[0]["Location"].ToString();
					dataRow[6] = dataSet3.Tables[0].Rows[0]["PMDays"].ToString();
					dataRow[7] = fun.FromDateDMY(dataSet3.Tables[0].Rows[0]["SysDate"].ToString());
					string cmdText3 = fun.select("SysDate,MachineId", "tblMS_PMBM_Master", "MachineId='" + dataSet.Tables[0].Rows[i]["MId"].ToString() + "' AND CompId='" + CompId + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					TimeSpan timeSpan = default(TimeSpan);
					string currDate = fun.getCurrDate();
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						timeSpan = Convert.ToDateTime(currDate) - Convert.ToDateTime(dataSet4.Tables[0].Rows[0]["SysDate"].ToString());
						dataRow[10] = fun.FromDateDMY(dataSet4.Tables[0].Rows[0]["SysDate"].ToString());
					}
					else
					{
						timeSpan = Convert.ToDateTime(currDate) - Convert.ToDateTime(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
					}
					dataRow[8] = ((double)Convert.ToInt32(dataSet3.Tables[0].Rows[0]["PMDays"]) - timeSpan.TotalDays).ToString();
				}
				dataRow[5] = dataSet.Tables[0].Rows[i]["StockQty"].ToString();
				dataRow[9] = dataSet.Tables[0].Rows[i]["MId"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			GridColour();
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
				num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblMId")).Text);
				int num2 = 0;
				num2 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				if (num2 != 0)
				{
					base.Response.Redirect("~/Module/Machinery/Transactions/PMBM_New_Details.aspx?MId=" + num + "&ItemId=" + num2 + "&ModId=15&SubModId=68");
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

	public void GridColour()
	{
		foreach (GridViewRow row in GridView2.Rows)
		{
			int num = Convert.ToInt32(((Label)row.FindControl("lblRemainDays")).Text);
			if (num <= 0)
			{
				row.BackColor = Color.Pink;
			}
		}
	}
}

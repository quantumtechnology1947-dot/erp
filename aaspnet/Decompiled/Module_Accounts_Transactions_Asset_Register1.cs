using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_Asset_Register1 : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FyId;

	private string SId = "";

	private string CDate = "";

	private string CTime = "";

	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	protected SqlDataSource SqlDataSource2;

	protected SqlDataSource SqlDataSource3;

	protected Panel Panel1;

	protected DropDownList ddlSearch;

	protected DropDownList ddlFinYear;

	protected DropDownList ddlAsset2;

	protected DropDownList ddlBGGroup2;

	protected Button btnSearch;

	protected Button btnExportToExcel;

	protected Label Label2;

	protected Panel Panel3;

	protected GridView GridView3;

	protected Panel Panel2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!base.IsPostBack)
			{
				FillData();
				Panel3.Visible = true;
			}
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
			FillData();
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			FillDataSearch();
			Panel3.Visible = false;
		}
		catch (Exception)
		{
		}
	}

	public void FillData()
	{
		try
		{
			con.Open();
			string cmdText = fun.select("*", "tblACC_Asset_Register", "FinYearId<='" + FyId + "' AND CompId='" + CompId + "' Order by Id DESC");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Asset", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BGGroup", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AssetNo", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				string cmdText2 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[1] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
				}
				string cmdText3 = fun.select("Abbrivation", "tblACC_Asset", "Id='" + dataSet.Tables[0].Rows[i]["AssetId"].ToString() + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText3, con);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					if (sqlDataReader.HasRows)
					{
						dataRow[2] = sqlDataReader["Abbrivation"].ToString();
					}
					else
					{
						dataRow[2] = "NA";
					}
				}
				string cmdText4 = fun.select("Symbol", "BusinessGroup", "Id='" + dataSet.Tables[0].Rows[i]["BGGroupId"].ToString() + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText4, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				while (sqlDataReader2.Read())
				{
					if (sqlDataReader2.HasRows)
					{
						dataRow[3] = sqlDataReader2["Symbol"].ToString();
					}
					else
					{
						dataRow[3] = "NA";
					}
				}
				dataRow[4] = dataSet.Tables[0].Rows[i]["AssetNumber"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			if (GridView2.Rows.Count > 0)
			{
				((Label)GridView2.FooterRow.FindControl("lblAssetNumber")).Text = "0000";
			}
			else
			{
				string cmdText5 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + FyId + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText5, con);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				while (sqlDataReader3.Read())
				{
					if (sqlDataReader3.HasRows)
					{
						Label label = (Label)GridView2.Controls[0].Controls[0].FindControl("LabelFinYear1");
						label.Text = sqlDataReader3["FinYear"].ToString();
					}
				}
			}
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Add")
			{
				string text = ((Label)GridView2.FooterRow.FindControl("lblAssetNumber")).Text;
				string selectedValue = ((DropDownList)GridView2.FooterRow.FindControl("ddlAsset")).SelectedValue;
				string selectedValue2 = ((DropDownList)GridView2.FooterRow.FindControl("ddlBGGroup")).SelectedValue;
				if (selectedValue != "1" && selectedValue2 != "1")
				{
					string cmdText = fun.insert("tblACC_Asset_Register", "SysDate, SysTime , CompId, FinYearId , SessionId, AssetId, BGGroupId , AssetNumber", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FyId + "','" + SId + "','" + selectedValue + "','" + selectedValue2 + "','" + text + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					FillData();
				}
				else
				{
					string empty = string.Empty;
					empty = "Invalid data entry.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			if (e.CommandName == "Add1")
			{
				string selectedValue3 = ((DropDownList)GridView2.Controls[0].Controls[0].FindControl("ddlAsset1")).SelectedValue;
				string selectedValue4 = ((DropDownList)GridView2.Controls[0].Controls[0].FindControl("ddlBGGroup1")).SelectedValue;
				if (selectedValue3 != "1" && selectedValue4 != "1")
				{
					string cmdText2 = fun.insert("tblACC_Asset_Register", "SysDate, SysTime , CompId, FinYearId , SessionId, AssetId, BGGroupId , AssetNumber", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FyId + "','" + SId + "','" + selectedValue3 + "','" + selectedValue4 + "','0001'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					FillData();
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Invalid data entry.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
			if (e.CommandName == "Del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				con.Open();
				string cmdText3 = fun.delete("tblACC_Asset_Register", "Id='" + num + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				sqlCommand3.ExecuteNonQuery();
				con.Close();
				FillData();
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillDataSearch()
	{
		try
		{
			con.Open();
			string text = "";
			if (ddlSearch.SelectedValue == "0")
			{
				text = string.Empty;
			}
			string text2 = "";
			if (ddlSearch.SelectedValue == "1")
			{
				text2 = " AND FinYearId='" + ddlFinYear.SelectedValue + "'";
			}
			string text3 = "";
			if (ddlSearch.SelectedValue == "2" && ddlAsset2.SelectedValue != "1")
			{
				text3 = " AND AssetId='" + ddlAsset2.SelectedValue + "'";
			}
			string text4 = "";
			if (ddlSearch.SelectedValue == "3" && ddlBGGroup2.SelectedValue != "1")
			{
				text4 = " AND BGGroupId='" + ddlBGGroup2.SelectedValue + "'";
			}
			string cmdText = fun.select("*", "tblACC_Asset_Register", "FinYearId<='" + FyId + "' AND CompId='" + CompId + "'" + text + text2 + text3 + text4 + " Order by Id DESC");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Asset", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BGGroup", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AssetNo", typeof(string)));
			int num = 0;
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				num++;
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = num;
				string cmdText2 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[1] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
				}
				string cmdText3 = fun.select("Abbrivation", "tblACC_Asset", "Id='" + dataSet.Tables[0].Rows[i]["AssetId"].ToString() + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText3, con);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					if (sqlDataReader.HasRows)
					{
						dataRow[2] = sqlDataReader["Abbrivation"].ToString();
					}
					else
					{
						dataRow[2] = "NA";
					}
				}
				string cmdText4 = fun.select("Symbol", "BusinessGroup", "Id='" + dataSet.Tables[0].Rows[i]["BGGroupId"].ToString() + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText4, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				while (sqlDataReader2.Read())
				{
					if (sqlDataReader2.HasRows)
					{
						dataRow[3] = sqlDataReader2["Symbol"].ToString();
					}
					else
					{
						dataRow[3] = "NA";
					}
				}
				dataRow[4] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["AssetNumber"]).ToString("D4");
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
			ViewState["dtList"] = dataTable;
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void ddlAsset_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			if (GridView2.Rows.Count > 0)
			{
				string selectedValue = ((DropDownList)GridView2.FooterRow.FindControl("ddlAsset")).SelectedValue;
				if (selectedValue != "1")
				{
					string cmdText = fun.select("AssetNumber", "tblACC_Asset_Register", "AssetId='" + selectedValue + "'  And CompId='" + CompId + "' order by AssetNumber desc");
					SqlCommand selectCommand = new SqlCommand(cmdText, con);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet, "tblACC_Asset_Register");
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						((Label)GridView2.FooterRow.FindControl("lblAssetNumber")).Text = (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4");
					}
					else
					{
						((Label)GridView2.FooterRow.FindControl("lblAssetNumber")).Text = "0001";
					}
				}
				else
				{
					((Label)GridView2.FooterRow.FindControl("lblAssetNumber")).Text = "0000";
				}
				con.Close();
			}
			else
			{
				((Label)GridView2.FooterRow.FindControl("lblAssetNumber")).Text = "0000";
			}
		}
		catch (Exception)
		{
		}
	}

	protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ddlSearch.SelectedValue == "1")
		{
			ddlFinYear.Visible = true;
			ddlAsset2.Visible = false;
			ddlBGGroup2.Visible = false;
			ddlAsset2.SelectedValue = "1";
			ddlBGGroup2.SelectedValue = "1";
		}
		else if (ddlSearch.SelectedValue == "2")
		{
			ddlAsset2.Visible = true;
			ddlBGGroup2.Visible = false;
			ddlFinYear.Visible = false;
			ddlBGGroup2.SelectedValue = "1";
		}
		else if (ddlSearch.SelectedValue == "3")
		{
			ddlBGGroup2.Visible = true;
			ddlAsset2.Visible = false;
			ddlFinYear.Visible = false;
			ddlAsset2.SelectedValue = "1";
		}
		else if (ddlSearch.SelectedValue == "0")
		{
			ddlBGGroup2.Visible = false;
			ddlAsset2.Visible = false;
			ddlFinYear.Visible = false;
			ddlAsset2.SelectedValue = "1";
			ddlBGGroup2.SelectedValue = "1";
		}
	}

	protected void btnExportToExcel_Click(object sender, EventArgs e)
	{
		try
		{
			DataTable dataTable = (DataTable)ViewState["dtList"];
			if (dataTable == null)
			{
				throw new Exception("No Records to Export");
			}
			string text = "D:\\ImportExcelFromDatabase\\myexcelfile_" + DateTime.Now.Day + "_" + DateTime.Now.Month + ".xls";
			FileInfo fileInfo = new FileInfo(text);
			StringWriter stringWriter = new StringWriter();
			HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
			DataGrid dataGrid = new DataGrid();
			dataGrid.DataSource = dataTable;
			dataGrid.DataBind();
			dataGrid.RenderControl(writer);
			string path = text.Substring(0, text.LastIndexOf("\\"));
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			StreamWriter streamWriter = new StreamWriter(text, append: true);
			stringWriter.ToString().Normalize();
			streamWriter.Write(stringWriter.ToString());
			streamWriter.Flush();
			streamWriter.Close();
			WriteAttachment(fileInfo.Name, "application/vnd.ms-excel", stringWriter.ToString());
		}
		catch (Exception)
		{
			string empty = string.Empty;
			empty = "No Records to Export.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
	}

	public static void WriteAttachment(string FileName, string FileType, string content)
	{
		try
		{
			HttpResponse response = HttpContext.Current.Response;
			response.ClearHeaders();
			response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
			response.ContentType = FileType;
			response.Write(content);
			response.End();
		}
		catch (Exception)
		{
		}
	}
}

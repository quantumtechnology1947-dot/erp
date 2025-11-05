using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_ProjectManagement_Transactions_ProjectPlanning : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FyId;

	private string SId = "";

	private string wono = "";

	private string wnup = "";

	private int h;

	protected TextBox txtWono;

	protected DropDownList DDLTaskWOType;

	protected Button btnSearch;

	protected Label lblWNo;

	protected GridView GridView2;

	protected Panel Panel1;

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
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!base.IsPostBack)
			{
				lblWNo.Text = wnup;
				FillDataUpLoad(wnup);
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
				FillData(wono, h);
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
			FillData(wono, h);
			lblWNo.Text = "";
			FillDataUpLoad(lblWNo.Text);
			Panel2.Visible = false;
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			FillData(wono, h);
			lblWNo.Text = "";
			FillDataUpLoad(lblWNo.Text);
			Panel2.Visible = false;
		}
		catch (Exception)
		{
		}
	}

	public void FillData(string wono, int c)
	{
		try
		{
			con.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ProjectTittle", typeof(string)));
			string text = "";
			if (txtWono.Text != "")
			{
				text = " AND WONo='" + txtWono.Text + "'";
			}
			string text2 = "";
			if (DDLTaskWOType.SelectedValue != "WO Category")
			{
				text2 = " AND CId='" + Convert.ToInt32(DDLTaskWOType.SelectedValue) + "'";
			}
			string cmdText = fun.select("*", "SD_Cust_WorkOrder_Master", "FinYearId<='" + FyId + "' AND CloseOpen='0' AND CompId='" + CompId + "'" + text + text2 + "Order by WONo ASC");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
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
				dataRow[2] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				dataRow[3] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["TaskWorkOrderDate"].ToString());
				dataRow[4] = dataSet.Tables[0].Rows[i]["TaskProjectTitle"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
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
			if (e.CommandName == "Abc")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				wnup = ((LinkButton)gridViewRow.FindControl("lbtnWONo")).Text;
				lblWNo.Text = wnup;
				FillDataUpLoad(wnup);
				Panel2.Visible = true;
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillDataUpLoad(string wnup)
	{
		try
		{
			con.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PLNDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FileName", typeof(string)));
			string cmdText = fun.select("*", "tblPM_ProjectPlanning_Master", "FinYearId<='" + FyId + "' AND CompId='" + CompId + "'  AND WONo='" + wnup + "' Order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				dataRow[2] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				if (dataSet.Tables[0].Rows[0]["FileName"].ToString() != "" && dataSet.Tables[0].Rows[0]["FileName"] != DBNull.Value)
				{
					dataRow[3] = "View";
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
			con.Close();
			if (GridView3.Rows.Count == 0)
			{
				((Label)GridView3.Controls[0].Controls[0].FindControl("lblWONo1")).Text = lblWNo.Text;
			}
			if (GridView3.Rows.Count > 0)
			{
				((Label)GridView3.FooterRow.FindControl("lblWONo2")).Text = lblWNo.Text;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView3.PageIndex = e.NewPageIndex;
			FillDataUpLoad(lblWNo.Text);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			if (e.CommandName == "Add")
			{
				string text = "";
				string text2 = ((Label)GridView3.FooterRow.FindControl("lblWONo2")).Text;
				HttpPostedFile postedFile = ((FileUpload)GridView3.FooterRow.FindControl("FileUpload1")).PostedFile;
				byte[] array = null;
				if ((FileUpload)GridView3.FooterRow.FindControl("FileUpload1") != null)
				{
					Stream inputStream = ((FileUpload)GridView3.FooterRow.FindControl("FileUpload1")).PostedFile.InputStream;
					BinaryReader binaryReader = new BinaryReader(inputStream);
					array = binaryReader.ReadBytes((int)inputStream.Length);
					text = Path.GetFileName(postedFile.FileName);
				}
				if (text != string.Empty && text2 != string.Empty)
				{
					string cmdText = fun.insert("tblPM_ProjectPlanning_Master", "SysDate, SysTime , CompId, FinYearId , SessionId, WONo, FileName , FileSize, ContentType, FileData", "'" + currDate + "','" + currTime + "','" + CompId + "','" + FyId + "','" + SId + "','" + text2 + "','" + text + "','" + array.Length + "','" + postedFile.ContentType + "',@Data");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					sqlCommand.Parameters.AddWithValue("@Data", array);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					FillDataUpLoad(text2);
				}
				else
				{
					string empty = string.Empty;
					empty = "Please Upload the file.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			if (e.CommandName == "Add1")
			{
				string text3 = "";
				_ = (GridViewRow)((Button)e.CommandSource).NamingContainer;
				string text4 = ((Label)GridView3.Controls[0].Controls[0].FindControl("lblWONo1")).Text;
				HttpPostedFile postedFile2 = ((FileUpload)GridView3.Controls[0].Controls[0].FindControl("FileUpload2")).PostedFile;
				byte[] array2 = null;
				if ((FileUpload)GridView3.Controls[0].Controls[0].FindControl("FileUpload2") != null)
				{
					Stream inputStream2 = ((FileUpload)GridView3.Controls[0].Controls[0].FindControl("FileUpload2")).PostedFile.InputStream;
					BinaryReader binaryReader2 = new BinaryReader(inputStream2);
					array2 = binaryReader2.ReadBytes((int)inputStream2.Length);
					text3 = Path.GetFileName(postedFile2.FileName);
				}
				if (text3 != string.Empty && text4 != string.Empty)
				{
					string cmdText2 = fun.insert("tblPM_ProjectPlanning_Master", "SysDate, SysTime , CompId, FinYearId , SessionId, WONo, FileName , FileSize, ContentType, FileData", "'" + currDate + "','" + currTime + "','" + CompId + "','" + FyId + "','" + SId + "','" + text4 + "','" + text3 + "','" + array2.Length + "','" + postedFile2.ContentType + "',@Data");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
					sqlCommand2.Parameters.AddWithValue("@Data", array2);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					FillDataUpLoad(text4);
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Please Upload the file.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
			if (e.CommandName == "del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				string text5 = ((Label)gridViewRow.FindControl("lblWONo")).Text;
				con.Open();
				string cmdText3 = fun.delete("tblPM_ProjectPlanning_Master", "CompId='" + CompId + "'AND Id='" + num + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				sqlCommand3.ExecuteNonQuery();
				con.Close();
				FillDataUpLoad(text5);
			}
			if (e.CommandName == "downloadImg")
			{
				GridViewRow gridViewRow2 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num2 = Convert.ToInt32(((Label)gridViewRow2.FindControl("lblId")).Text);
				base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num2 + "&tbl=tblPM_ProjectPlanning_Master&qfd=FileData&qfn=FileName&qct=ContentType");
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
			int c = Convert.ToInt32(DDLTaskWOType.SelectedValue);
			FillData(wono, c);
		}
		else
		{
			FillData(wono, h);
		}
	}
}

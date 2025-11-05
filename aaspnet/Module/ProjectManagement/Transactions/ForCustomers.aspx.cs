using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_ProjectManagement_Transactions_ForCustomers : Page, IRequiresSessionState
{
	protected Label Label2;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected Button Search;

	protected Label Label3;

	protected TextBox TxtEmpName;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Label lblUser;

	protected Label Label4;

	protected TextBox txtTitle;

	protected Label lblTitle;

	protected Label Label5;

	protected GridView GridView3;

	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string connStr = "";

	private MailMessage msg = new MailMessage();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
		}
		catch (Exception)
		{
		}
	}

	protected void Search_Click(object sender, EventArgs e)
	{
		if (fun.getCode(TxtSearchValue.Text) != "")
		{
			FillDataUpLoad(fun.getCode(TxtSearchValue.Text));
		}
	}

	public void FillDataUpLoad(string CustId)
	{
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PLNDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FileName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Time", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MailTo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("msg", typeof(string)));
			string cmdText = fun.select("tblPM_ForCustomer_Master.Id,tblPM_ForCustomer_Details.MailTo,tblPM_ForCustomer_Details.Message,tblPM_ForCustomer_Details.Id as DId,tblPM_ForCustomer_Master.SysDate,tblPM_ForCustomer_Master.SysTime,tblPM_ForCustomer_Details.FileName,tblPM_ForCustomer_Details.Remarks,tblPM_ForCustomer_Master.EmpId,tblPM_ForCustomer_Master.Title", "tblPM_ForCustomer_Master,tblPM_ForCustomer_Details", "tblPM_ForCustomer_Master.Id=tblPM_ForCustomer_Details.MId AND tblPM_ForCustomer_Master.FinYearId<='" + FinYearId + "' AND tblPM_ForCustomer_Master.CompId='" + CompId + "' AND tblPM_ForCustomer_Master.CustId='" + CustId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				TxtEmpName.Visible = false;
				txtTitle.Visible = false;
				lblUser.Visible = true;
				lblTitle.Visible = true;
				string cmdText2 = fun.select("Title+'. '+EmployeeName as Name", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + dataSet.Tables[0].Rows[0]["EmpId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				lblUser.Text = dataSet2.Tables[0].Rows[0][0].ToString() + " [" + dataSet.Tables[0].Rows[0]["EmpId"].ToString() + "]";
				lblTitle.Text = dataSet.Tables[0].Rows[0]["Title"].ToString();
			}
			else
			{
				TxtEmpName.Text = "";
				txtTitle.Text = "";
				TxtEmpName.Visible = true;
				txtTitle.Visible = true;
				lblUser.Visible = false;
				lblTitle.Visible = false;
			}
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				if (dataSet.Tables[0].Rows[i]["FileName"].ToString() != "" && dataSet.Tables[0].Rows[i]["FileName"] != DBNull.Value)
				{
					dataRow[2] = dataSet.Tables[0].Rows[i]["FileName"].ToString();
				}
				dataRow[3] = dataSet.Tables[0].Rows[i]["DId"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["Remarks"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["SysTime"].ToString();
				dataRow[6] = dataSet.Tables[0].Rows[i]["MailTo"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["Message"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		con.Open();
		string currDate = fun.getCurrDate();
		string currTime = fun.getCurrTime();
		string code = fun.getCode(TxtSearchValue.Text);
		if (e.CommandName == "Add")
		{
			string code2 = fun.getCode(lblUser.Text);
			string text = lblTitle.Text;
			string text2 = "";
			string text3 = ((TextBox)GridView3.FooterRow.FindControl("txtRemarks")).Text;
			string text4 = ((TextBox)GridView3.FooterRow.FindControl("txtmailto")).Text;
			string text5 = ((TextBox)GridView3.FooterRow.FindControl("txtmsg")).Text;
			if (GridView3.FooterRow.FindControl("FileUpload1") is FileUpload { PostedFile: var postedFile } fileUpload)
			{
				byte[] array = null;
				Stream inputStream = fileUpload.PostedFile.InputStream;
				BinaryReader binaryReader = new BinaryReader(inputStream);
				array = binaryReader.ReadBytes((int)inputStream.Length);
				text2 = Path.GetFileName(postedFile.FileName);
				if (code != string.Empty && code2 != string.Empty && text != string.Empty && text2 != string.Empty)
				{
					string cmdText = fun.insert("tblPM_ForCustomer_Master", "SysDate, SysTime , CompId, FinYearId , SessionId, CustId,EmpId, Title", "'" + currDate + "','" + currTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + code + "','" + code2 + "','" + text + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					sqlCommand.Parameters.AddWithValue("@Data", array);
					sqlCommand.ExecuteNonQuery();
					string cmdText2 = fun.select("Id", "tblPM_ForCustomer_Master", "CompId='" + CompId + "' Order by Id Desc");
					SqlCommand selectCommand = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					string cmdText3 = fun.insert("tblPM_ForCustomer_Details", "MId, FileName , FileSize, ContentType , FileData,MailTo,Message,Remarks", "'" + dataSet.Tables[0].Rows[0][0].ToString() + "','" + text2 + "','" + array.Length + "','" + postedFile.ContentType + "',@Data,'" + text4 + "','" + text5 + "','" + text3 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					sqlCommand2.Parameters.AddWithValue("@Data", array);
					sqlCommand2.ExecuteNonQuery();
					FillDataUpLoad(code);
				}
				else
				{
					string empty = string.Empty;
					empty = "Invalid input data.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
				binaryReader.Close();
				inputStream.Close();
			}
		}
		if (e.CommandName == "Add1")
		{
			string code3 = fun.getCode(TxtEmpName.Text);
			string text6 = txtTitle.Text;
			string text7 = "";
			string text8 = ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtRemarks")).Text;
			string text9 = ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtmailTo")).Text;
			string text10 = ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtmsg")).Text;
			FileUpload fileUpload2 = GridView3.Controls[0].Controls[0].FindControl("FileUpload2") as FileUpload;
			HttpPostedFile postedFile2 = fileUpload2.PostedFile;
			byte[] array2 = null;
			if (fileUpload2 != null)
			{
				Stream inputStream2 = fileUpload2.PostedFile.InputStream;
				BinaryReader binaryReader2 = new BinaryReader(inputStream2);
				array2 = binaryReader2.ReadBytes((int)inputStream2.Length);
				text7 = Path.GetFileName(postedFile2.FileName);
				if (code != string.Empty && code3 != string.Empty && text6 != string.Empty && text7 != string.Empty)
				{
					string cmdText4 = fun.insert("tblPM_ForCustomer_Master", "SysDate, SysTime , CompId, FinYearId , SessionId, CustId,EmpId, Title", "'" + currDate + "','" + currTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + code + "','" + code3 + "','" + text6 + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText4, con);
					sqlCommand3.Parameters.AddWithValue("@Data", array2);
					sqlCommand3.ExecuteNonQuery();
					string cmdText5 = fun.select("Id", "tblPM_ForCustomer_Master", "CompId='" + CompId + "' Order by Id Desc");
					SqlCommand selectCommand2 = new SqlCommand(cmdText5, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					string cmdText6 = fun.insert("tblPM_ForCustomer_Details", "MId, FileName , FileSize, ContentType , FileData,MailTo,Message,Remarks", "'" + dataSet2.Tables[0].Rows[0][0].ToString() + "','" + text7 + "','" + array2.Length + "','" + postedFile2.ContentType + "',@Data,'" + text9 + "','" + text10 + "','" + text8 + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText6, con);
					sqlCommand4.Parameters.AddWithValue("@Data", array2);
					sqlCommand4.ExecuteNonQuery();
					FillDataUpLoad(code);
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Invalid input data.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
				binaryReader2.Close();
				inputStream2.Close();
			}
		}
		if (e.CommandName == "del")
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
			int num2 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblDId")).Text);
			string cmdText7 = fun.delete("tblPM_ForCustomer_Details", "Id='" + num2 + "'");
			SqlCommand sqlCommand5 = new SqlCommand(cmdText7, con);
			sqlCommand5.ExecuteNonQuery();
			string cmdText8 = fun.select("Id", "tblPM_ForCustomer_Details", "MId='" + num + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText8, con);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3);
			if (dataSet3.Tables[0].Rows.Count == 0)
			{
				string cmdText9 = fun.delete("tblPM_ForCustomer_Master", "Id='" + num + "'");
				SqlCommand sqlCommand6 = new SqlCommand(cmdText9, con);
				sqlCommand6.ExecuteNonQuery();
				FillDataUpLoad(code);
			}
			FillDataUpLoad(code);
		}
		if (e.CommandName == "downloadImg")
		{
			GridViewRow gridViewRow2 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			int num3 = Convert.ToInt32(((Label)gridViewRow2.FindControl("lblDId")).Text);
			base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num3 + "&tbl=tblPM_ForCustomer_Details&qfd=FileData&qfn=FileName&qct=ContentType");
		}
		con.Close();
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

	[WebMethod]
	[ScriptMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblHR_OfficeStaff");
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

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView3.PageIndex = e.NewPageIndex;
			if (fun.getCode(TxtSearchValue.Text) != "")
			{
				FillDataUpLoad(fun.getCode(TxtSearchValue.Text));
			}
		}
		catch (Exception)
		{
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_HR_Transactions_NewsandNotices_Edit_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string id = "";

	private int CId;

	protected TextBox TxtNewsTitle;

	protected RequiredFieldValidator ReqTitle;

	protected TextBox txtNews;

	protected RequiredFieldValidator ReqDesc0;

	protected TextBox TxtFromDate;

	protected CalendarExtender TxtFromDate_CalendarExtender;

	protected RequiredFieldValidator ReqFdate;

	protected RegularExpressionValidator RegFromDateVal;

	protected TextBox TxtToDate;

	protected CalendarExtender TxtToDate_CalendarExtender;

	protected RequiredFieldValidator ReqToDate;

	protected RegularExpressionValidator ReqToDateVal;

	protected HyperLink HyperLink1;

	protected ImageButton ImageCross;

	protected FileUpload FileUpload1;

	protected Button BtnUpload;

	protected Button BtnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		CId = Convert.ToInt32(Session["compid"]);
		try
		{
			TxtFromDate.Attributes.Add("readonly", "readonly");
			TxtToDate.Attributes.Add("readonly", "readonly");
			id = base.Request.QueryString["Id"];
			if (!base.IsPostBack)
			{
				sqlConnection.Open();
				string cmdText = fun.select(" Id, Title, InDetails,REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(FromDate, CHARINDEX('-', FromDate) + 1, 2) + '-' + LEFT (FromDate, CHARINDEX('-', FromDate) - 1) + '-' + RIGHT (FromDate, CHARINDEX('-', REVERSE(FromDate)) - 1)), 103), '/', '-') AS FromDate, REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(ToDate, CHARINDEX('-', ToDate) + 1, 2) + '-' + LEFT (ToDate, CHARINDEX('-', ToDate) - 1) + '-' + RIGHT (ToDate, CHARINDEX('-', REVERSE(ToDate)) - 1)), 103), '/', '-') AS ToDate, FileName, FileSize, ContentType, FileData", "tblHR_News_Notices", "Id='" + id + "' AND CompId='" + CId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				TxtNewsTitle.Text = dataSet.Tables[0].Rows[0]["Title"].ToString();
				txtNews.Text = dataSet.Tables[0].Rows[0]["InDetails"].ToString();
				TxtFromDate.Text = dataSet.Tables[0].Rows[0]["FromDate"].ToString();
				TxtToDate.Text = dataSet.Tables[0].Rows[0]["ToDate"].ToString();
				if (dataSet.Tables[0].Rows[0]["FileName"].ToString() == "")
				{
					FileUpload1.Visible = true;
					ImageCross.Visible = false;
					HyperLink1.Visible = false;
				}
				else
				{
					FileUpload1.Visible = false;
					ImageCross.Visible = true;
					HyperLink1.Text = dataSet.Tables[0].Rows[0]["FileName"].ToString();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnUpload_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (!(TxtNewsTitle.Text != "") || !(txtNews.Text != "") || !(TxtFromDate.Text != "") || !(TxtToDate.Text != ""))
			{
				return;
			}
			string currTime = fun.getCurrTime();
			string text = base.Request.QueryString["Id"];
			string text2 = Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
			string text3 = fun.FromDate(TxtFromDate.Text);
			string text4 = fun.FromDate(TxtToDate.Text);
			string text5 = "";
			sqlConnection.Open();
			DateTime now = DateTime.Now;
			string text6 = Convert.ToDateTime(now).ToString("yyyy-MM-dd");
			string text7 = "0";
			if (Convert.ToDateTime(text6) > Convert.ToDateTime(text4))
			{
				text7 = "1";
			}
			string text8 = "";
			if (txtNews.Text != "" && TxtNewsTitle.Text != "" && fun.DateValidation(TxtFromDate.Text) && fun.DateValidation(TxtToDate.Text))
			{
				text8 = fun.update("tblHR_News_Notices", "SysDate='" + text6 + "',SysTime='" + currTime.ToString() + "',SessionId='" + text2 + "',CompId='" + CId + "',FinYearId='" + num + "',Title='" + TxtNewsTitle.Text + "',InDetails='" + txtNews.Text + "',FromDate='" + text3 + "',ToDate='" + text4 + "',Flag='" + text7 + "'", "Id='" + text + "'AND CompId='" + CId + "'");
				SqlCommand cmd = new SqlCommand(text8, sqlConnection);
				fun.InsertUpdateData(cmd);
				HttpPostedFile postedFile = FileUpload1.PostedFile;
				byte[] array = null;
				if (FileUpload1.PostedFile != null)
				{
					Stream inputStream = FileUpload1.PostedFile.InputStream;
					BinaryReader binaryReader = new BinaryReader(inputStream);
					array = binaryReader.ReadBytes((int)inputStream.Length);
					text5 = Path.GetFileName(postedFile.FileName);
					string cmdText = fun.update("tblHR_News_Notices", "FileName='" + text5 + "',FileSize='" + array.Length + "',ContentType='" + postedFile.ContentType + "',FileData=@Data", "Id='" + text + "'AND CompId='" + CId + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.Parameters.AddWithValue("@Data", array);
					fun.InsertUpdateData(sqlCommand);
				}
				base.Response.Redirect("NewsandNotices_Edit.aspx?ModId=12&SubModId=29");
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("NewsandNotices_edit.aspx?ModId=12&SubModId=29");
	}

	protected void ImageCross_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string text = "";
			text = fun.update("tblHR_News_Notices", "FileName='',FileSize='0',ContentType=''", "Id='" + id + "'AND CompId='" + CId + "'");
			SqlCommand cmd = new SqlCommand(text, connection);
			fun.InsertUpdateData(cmd);
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}
}

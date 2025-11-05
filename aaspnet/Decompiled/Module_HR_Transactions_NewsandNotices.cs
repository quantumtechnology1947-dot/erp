using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_HR_Transactions_NewsandNotices : Page, IRequiresSessionState
{
	protected TextBox TxtNewsTitle;

	protected RequiredFieldValidator ReqTitle;

	protected TextBox txtNews;

	protected RequiredFieldValidator ReqTitle0;

	protected TextBox TxtFromDate;

	protected RequiredFieldValidator ReqTitle1;

	protected RegularExpressionValidator RegFromDateVal;

	protected CalendarExtender TxtFromDate_CalendarExtender;

	protected TextBox TxtToDate;

	protected CalendarExtender TxtToDate_CalendarExtender;

	protected RequiredFieldValidator ReqTitle2;

	protected RegularExpressionValidator RegToDateVal;

	protected FileUpload FileUpload1;

	protected Button BtnUpload;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		TxtFromDate.Attributes.Add("readonly", "readonly");
		TxtToDate.Attributes.Add("readonly", "readonly");
	}

	protected void BtnUpload_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		string currDate = fun.getCurrDate();
		string currTime = fun.getCurrTime();
		try
		{
			string text = Session["username"].ToString();
			int num = Convert.ToInt32(Session["compid"]);
			int num2 = Convert.ToInt32(Session["finyear"]);
			string text2 = fun.FromDate(TxtFromDate.Text);
			string text3 = fun.FromDate(TxtToDate.Text);
			string text4 = "";
			HttpPostedFile postedFile = FileUpload1.PostedFile;
			byte[] array = null;
			if (TxtNewsTitle.Text != "" && txtNews.Text != "" && text2.ToString() != "" && text3.ToString() != "")
			{
				if (FileUpload1.PostedFile != null)
				{
					Stream inputStream = FileUpload1.PostedFile.InputStream;
					BinaryReader binaryReader = new BinaryReader(inputStream);
					array = binaryReader.ReadBytes((int)inputStream.Length);
					text4 = Path.GetFileName(postedFile.FileName);
				}
				sqlConnection.Open();
				if (txtNews.Text != "" && TxtNewsTitle.Text != "" && fun.DateValidation(TxtFromDate.Text) && fun.DateValidation(TxtToDate.Text))
				{
					string cmdText = fun.insert("tblHR_News_Notices", "SysDate,SysTime,SessionId,CompId,FinYearId,Title,InDetails,FromDate,ToDate,FileName,FileSize,ContentType,FileData", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + text + "','" + num + "','" + num2 + "','" + TxtNewsTitle.Text + "','" + txtNews.Text + "','" + text2 + "','" + text3 + "','" + text4 + "','" + array.Length + "','" + postedFile.ContentType + "' ,@Data");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.Parameters.AddWithValue("@Data", array);
					fun.InsertUpdateData(sqlCommand);
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
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
}

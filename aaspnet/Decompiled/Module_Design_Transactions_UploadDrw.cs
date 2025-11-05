using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Transactions_UploadDrw : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string wono = "";

	private string id = "";

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private string CDate = "";

	private string CTime = "";

	private string img = "";

	protected FileUpload FileUpload1;

	protected Button bynUpload;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			wono = base.Request.QueryString["WONo"].ToString();
			img = base.Request.QueryString["img"].ToString();
			id = base.Request.QueryString["Id"].ToString();
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("TPL_Design_WO_TreeView_Edit.aspx?WONo=" + wono + "&PgUrl=TPL_Design_WO_TreeView.aspx&ModId=3&SubModId=23&id=" + id);
	}

	protected void bynUpload_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			HttpPostedFile postedFile = FileUpload1.PostedFile;
			byte[] array = null;
			if (FileUpload1.PostedFile != null)
			{
				Stream inputStream = FileUpload1.PostedFile.InputStream;
				BinaryReader binaryReader = new BinaryReader(inputStream);
				array = binaryReader.ReadBytes((int)inputStream.Length);
				text = Path.GetFileName(postedFile.FileName);
			}
			if (img == "0")
			{
				string cmdText = fun.update("tblDG_Item_Master", "SysDate='" + CDate.ToString() + "',SysTime='" + CTime.ToString() + "',SessionId='" + sId.ToString() + "',FileName='" + text + "',FileSize='" + array.Length + "',ContentType='" + postedFile.ContentType + "',FileData=@Data", "CompId='" + CompId + "' AND Id='" + id + "'");
				string connectionString = fun.Connection();
				con = new SqlConnection(connectionString);
				con.Open();
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.Parameters.AddWithValue("@Data", array);
				fun.InsertUpdateData(sqlCommand);
			}
			else
			{
				string cmdText2 = fun.update("tblDG_Item_Master", "SysDate='" + CDate.ToString() + "',SysTime='" + CTime.ToString() + "',SessionId='" + sId.ToString() + "',AttName='" + text + "',AttSize='" + array.Length + "',AttContentType='" + postedFile.ContentType + "',AttData=@Data", "CompId='" + CompId + "' AND Id='" + id + "'");
				string connectionString2 = fun.Connection();
				con = new SqlConnection(connectionString2);
				con.Open();
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				sqlCommand2.Parameters.AddWithValue("@Data", array);
				fun.InsertUpdateData(sqlCommand2);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MROffice_Transactions_MROffice : Page, IRequiresSessionState
{
	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	protected Panel Panel1;

	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string CompId = string.Empty;

	private string FinYearId = string.Empty;

	private string SessionId = string.Empty;

	private string constr = string.Empty;

	private string CurrDate = string.Empty;

	private string CurrTime = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			constr = fun.Connection();
			con = new SqlConnection(constr);
			CompId = Session["compid"].ToString();
			FinYearId = Session["finyear"].ToString();
			SessionId = Session["username"].ToString();
			if (!base.IsPostBack)
			{
				BindData();
			}
		}
		catch (Exception)
		{
		}
	}

	public void BindData()
	{
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Id", typeof(int));
			dataTable.Columns.Add("ForModule", typeof(string));
			dataTable.Columns.Add("Format", typeof(string));
			dataTable.Columns.Add("FileName", typeof(string));
			string cmdText = fun.select("*", "tblMROffice", "CompId='" + CompId + "' Order by ForModule ASC");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				string cmdText2 = fun.select("*", "tblModule_Master", "ModId='" + dataSet.Tables[0].Rows[i]["ForModule"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				dataRow[1] = dataSet2.Tables[0].Rows[0]["ModName"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["Format"].ToString();
				if (dataSet.Tables[0].Rows[i]["FileName"].ToString() != "" && dataSet.Tables[0].Rows[i]["FileName"] != DBNull.Value)
				{
					dataRow[3] = dataSet.Tables[0].Rows[i]["FileName"].ToString();
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			CurrDate = fun.getCurrDate();
			CurrTime = fun.getCurrTime();
			con.Open();
			if (e.CommandName == "Add")
			{
				int num = Convert.ToInt32(((DropDownList)GridView2.FooterRow.FindControl("drpFor")).SelectedValue);
				string text = ((TextBox)GridView2.FooterRow.FindControl("txtFormat")).Text;
				string text2 = "";
				HttpPostedFile postedFile = ((FileUpload)GridView2.FooterRow.FindControl("FileUploadAtt")).PostedFile;
				byte[] array = null;
				if ((FileUpload)GridView2.FooterRow.FindControl("FileUploadAtt") != null)
				{
					Stream inputStream = ((FileUpload)GridView2.FooterRow.FindControl("FileUploadAtt")).PostedFile.InputStream;
					BinaryReader binaryReader = new BinaryReader(inputStream);
					array = binaryReader.ReadBytes((int)inputStream.Length);
					text2 = Path.GetFileName(postedFile.FileName);
				}
				string cmdText = fun.insert("tblMROffice", "SysDate,SysTime,CompId,SessionId,FinYearId,ForModule,Format,FileName,Size,ContentType,Data", "'" + CurrDate + "','" + CurrTime + "','" + CompId + "','" + SessionId + "','" + FinYearId + "','" + num + "','" + text + "','" + text2 + "','" + array.Length + "','" + postedFile.ContentType + "',@Data");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.Parameters.AddWithValue("@Data", array);
				sqlCommand.ExecuteNonQuery();
				BindData();
			}
			if (e.CommandName == "AddEmpty")
			{
				int num2 = Convert.ToInt32(((DropDownList)GridView2.Controls[0].Controls[0].FindControl("drpFor")).SelectedValue);
				string text3 = ((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtFormat")).Text;
				string text4 = "";
				HttpPostedFile postedFile2 = ((FileUpload)GridView2.Controls[0].Controls[0].FindControl("FileUploadAtt")).PostedFile;
				byte[] array2 = null;
				if ((FileUpload)GridView2.Controls[0].Controls[0].FindControl("FileUploadAtt") != null)
				{
					Stream inputStream2 = ((FileUpload)GridView2.Controls[0].Controls[0].FindControl("FileUploadAtt")).PostedFile.InputStream;
					BinaryReader binaryReader2 = new BinaryReader(inputStream2);
					array2 = binaryReader2.ReadBytes((int)inputStream2.Length);
					text4 = Path.GetFileName(postedFile2.FileName);
				}
				string cmdText2 = fun.insert("tblMROffice", "SysDate,SysTime,CompId,SessionId,FinYearId,ForModule,Format,FileName,Size,ContentType,Data", "'" + CurrDate + "','" + CurrTime + "','" + CompId + "','" + SessionId + "','" + FinYearId + "','" + num2 + "','" + text3 + "','" + text4 + "','" + array2.Length + "','" + postedFile2.ContentType + "',@Data");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				sqlCommand2.Parameters.AddWithValue("@Data", array2);
				sqlCommand2.ExecuteNonQuery();
				BindData();
			}
			if (e.CommandName == "Download")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num3 = Convert.ToInt32(((HiddenField)gridViewRow.FindControl("hidId")).Value);
				base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num3 + "&tbl=tblMROffice&qfd=Data&qfn=FileName&qct=ContentType");
			}
			if (e.CommandName == "Delete")
			{
				GridViewRow gridViewRow2 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num4 = Convert.ToInt32(((HiddenField)gridViewRow2.FindControl("hidId")).Value);
				string text5 = fun.delete("tblMROffice", "Id='" + num4 + "'");
				base.Response.Write(text5);
				SqlCommand sqlCommand3 = new SqlCommand(text5, con);
				sqlCommand3.ExecuteNonQuery();
				BindData();
			}
			con.Close();
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
			BindData();
		}
		catch (Exception)
		{
		}
	}
}

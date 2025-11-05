using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Others_Security_GatePass : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	public void fillgrid()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GPNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FromDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FromTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ToTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TypeFor", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Reason", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AuthorizedBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AuthorizeDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AuthorizeTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Feedback", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("SelfEId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Authorize", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Place", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ContactNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Empother", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ToDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ImageUrl", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
			string cmdText = fun.select("tblGate_Pass.SessionId,tblGate_Pass.CompId,tblGate_Pass.SysDate,tblGate_Pass.Authorize,tblGate_Pass.EmpId As SelfEId,tblGate_Pass.Id,tblGate_Pass.FinYearId,tblGate_Pass.GPNo,tblGate_Pass.Authorize,tblGate_Pass.AuthorizedBy,tblGate_Pass.AuthorizeDate,tblGate_Pass.AuthorizeTime,tblGatePass_Details.FromDate,tblGatePass_Details.TypeOf,tblGatePass_Details.FromTime,tblGatePass_Details.ToTime,tblGatePass_Details.Type,tblGatePass_Details.TypeFor,tblGatePass_Details.Reason,tblGatePass_Details.Feedback,tblGatePass_Details.Id As DId,tblGatePass_Details.EmpId As OtherEId,tblGatePass_Details.Place,tblGatePass_Details.ContactPerson,tblGatePass_Details.ContactNo", "tblGate_Pass,tblGatePass_Details", "tblGate_Pass.Id=tblGatePass_Details.MId AND tblGate_Pass.Authorize='1' AND tblGatePass_Details.FromDate='" + fun.getCurrDate() + "'  order by tblGate_Pass.Id");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				string value = string.Empty;
				string value2 = string.Empty;
				string value3 = string.Empty;
				string value4 = string.Empty;
				string cmdText2 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + sqlDataReader["FinYearId"].ToString() + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				dataRow[0] = sqlDataReader["Id"].ToString();
				dataRow[1] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				dataRow[2] = sqlDataReader["GPNo"].ToString();
				dataRow[3] = fun.FromDate(sqlDataReader["FromDate"].ToString());
				dataRow[4] = sqlDataReader["FromTime"].ToString();
				dataRow[5] = sqlDataReader["ToTime"].ToString();
				if (sqlDataReader["TypeOf"].ToString() == "1")
				{
					value4 = "WONo :" + sqlDataReader["TypeFor"].ToString();
				}
				else if (sqlDataReader["TypeOf"].ToString() == "2")
				{
					value4 = "Enquiry :" + sqlDataReader["TypeFor"].ToString();
				}
				else if (sqlDataReader["TypeOf"].ToString() == "3")
				{
					value4 = sqlDataReader["TypeFor"].ToString();
				}
				dataRow[7] = value4;
				dataRow[8] = sqlDataReader["Reason"].ToString();
				string cmdText3 = fun.select("*", "tblGatePass_Reason", "Id='" + sqlDataReader["Type"].ToString() + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				dataRow[6] = sqlDataReader3["Reason"].ToString();
				if (Convert.ToInt32(sqlDataReader["Authorize"]) == 1)
				{
					string cmdText4 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + sqlDataReader["AuthorizedBy"].ToString() + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					sqlDataReader4.Read();
					value = sqlDataReader4["Title"].ToString() + ". " + sqlDataReader4["EmployeeName"].ToString();
					value2 = fun.FromDateDMY(sqlDataReader["AuthorizeDate"].ToString());
					value3 = sqlDataReader["AuthorizeTime"].ToString();
				}
				dataRow[9] = value;
				dataRow[10] = value2;
				dataRow[11] = value3;
				if (sqlDataReader["Feedback"] != DBNull.Value)
				{
					sqlDataReader["Feedback"].ToString();
				}
				dataRow[12] = sqlDataReader["Feedback"].ToString();
				dataRow[13] = sqlDataReader["DId"].ToString();
				string text = string.Empty;
				string text2 = string.Empty;
				string value5 = string.Empty;
				_ = string.Empty;
				if (sqlDataReader["SelfEId"] != DBNull.Value)
				{
					string cmdText5 = fun.select("tblHR_OfficeStaff.Title,tblHR_OfficeStaff.EmployeeName,tblHR_OfficeStaff.EmpId,BusinessGroup.Symbol,tblHR_OfficeStaff.PhotoFileName,tblHR_OfficeStaff.PhotoSize,tblHR_OfficeStaff.PhotoContentType,tblHR_OfficeStaff.PhotoData", "tblHR_OfficeStaff,BusinessGroup", "tblHR_OfficeStaff.EmpId='" + sqlDataReader["SelfEId"].ToString() + "'And tblHR_OfficeStaff.BGGroup=BusinessGroup.Id ");
					SqlCommand sqlCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
					sqlDataReader5.Read();
					if (sqlDataReader5.HasRows)
					{
						text = sqlDataReader5["Title"].ToString() + ". " + sqlDataReader5["EmployeeName"].ToString();
						value5 = sqlDataReader5["Symbol"].ToString();
						dataRow[22] = string.Format("Handler.ashx?EmpId={0}", sqlDataReader["SelfEId"].ToString());
						dataRow[23] = sqlDataReader["SelfEId"].ToString();
					}
				}
				else
				{
					string cmdText6 = fun.select("tblHR_OfficeStaff.Title,tblHR_OfficeStaff.EmployeeName,tblHR_OfficeStaff.EmpId,BusinessGroup.Symbol,tblHR_OfficeStaff.PhotoFileName,tblHR_OfficeStaff.PhotoSize,tblHR_OfficeStaff.PhotoContentType,tblHR_OfficeStaff.PhotoData", "tblHR_OfficeStaff,BusinessGroup", "EmpId='" + sqlDataReader["OtherEId"].ToString() + "'And tblHR_OfficeStaff.BGGroup=BusinessGroup.Id ");
					SqlCommand sqlCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
					sqlDataReader6.Read();
					if (sqlDataReader6.HasRows)
					{
						text2 = sqlDataReader6["Title"].ToString() + ". " + sqlDataReader6["EmployeeName"].ToString();
						value5 = sqlDataReader6["Symbol"].ToString();
						dataRow[22] = string.Format("Handler.ashx?EmpId={0}", sqlDataReader["OtherEId"].ToString());
						dataRow[23] = sqlDataReader["OtherEId"].ToString();
					}
				}
				dataRow[14] = text + text2;
				dataRow[15] = sqlDataReader["Authorize"].ToString();
				dataRow[16] = sqlDataReader["Place"].ToString();
				dataRow[17] = sqlDataReader["ContactPerson"].ToString();
				dataRow[18] = sqlDataReader["ContactNo"].ToString();
				string cmdText7 = fun.select("Title,EmployeeName,EmpId", "tblHR_OfficeStaff", "EmpId='" + sqlDataReader["Sessionid"].ToString() + "'");
				SqlCommand sqlCommand7 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
				sqlDataReader7.Read();
				dataRow[19] = sqlDataReader7["Title"].ToString() + ". " + sqlDataReader7["EmployeeName"].ToString();
				dataRow[20] = Convert.ToInt32(sqlDataReader["CompId"]);
				dataRow[21] = value5;
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			fillgrid();
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		fillgrid();
	}
}

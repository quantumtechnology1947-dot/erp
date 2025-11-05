using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Admin_Access_AccessModule_Details : Page, IRequiresSessionState
{
	protected Label lblCompName;

	protected Label lblFinYear;

	protected Label lblEmpName;

	protected Label lblModuleName;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Button BtnSave;

	protected Button BtnCancel;

	protected Label lblmsg;

	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string EmpId = "";

	private string ModId = "";

	private string connStr = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			con.Open();
			sId = Session["username"].ToString();
			EmpId = base.Request.QueryString["EmpId"].ToString();
			ModId = base.Request.QueryString["modid"].ToString();
			CompId = Convert.ToInt32(base.Request.QueryString["CompId"]);
			FinYearId = Convert.ToInt32(base.Request.QueryString["FYId"]);
			lblmsg.Text = "";
			if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
			{
				lblmsg.Text = base.Request.QueryString["msg"].ToString();
			}
			if (!base.IsPostBack)
			{
				BindData();
				foreach (GridViewRow row in GridView2.Rows)
				{
					string text = ((Label)row.FindControl("lblId")).Text;
					string cmdText = fun.select("*", "tblAccess_Master", "CompId='" + CompId + "'AND FinYearId='" + FinYearId + "' AND EmpId='" + EmpId + "' AND ModId='" + ModId + "' AND SubModId='" + text + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						switch (Convert.ToInt32(sqlDataReader["Access"]))
						{
						case 1:
							((CheckBox)row.FindControl("Cknew")).Checked = true;
							break;
						case 2:
							((CheckBox)row.FindControl("CkEdit")).Checked = true;
							break;
						case 3:
							((CheckBox)row.FindControl("CkDelete")).Checked = true;
							break;
						case 4:
							((CheckBox)row.FindControl("CkPrint")).Checked = true;
							break;
						}
					}
					string cmdText2 = fun.select("*", "tblSubModLink_Master", "SubModId='" + text + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					while (sqlDataReader2.Read())
					{
						switch (Convert.ToInt32(sqlDataReader2["Access"]))
						{
						case 1:
							((CheckBox)row.FindControl("Cknew")).Visible = true;
							break;
						case 2:
							((CheckBox)row.FindControl("CkEdit")).Visible = true;
							break;
						case 3:
							((CheckBox)row.FindControl("CkDelete")).Visible = true;
							break;
						case 4:
							((CheckBox)row.FindControl("CkPrint")).Visible = true;
							break;
						}
					}
				}
			}
			lblCompName.Text = fun.getCompany(CompId);
			string cmdText3 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + FinYearId + "'");
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
			SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
			while (sqlDataReader3.Read())
			{
				lblFinYear.Text = sqlDataReader3["FinYear"].ToString();
			}
			string cmdText4 = fun.select("EmployeeName", "tblHR_OfficeStaff", "EmpId='" + EmpId + "'");
			SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
			SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
			while (sqlDataReader4.Read())
			{
				lblEmpName.Text = sqlDataReader4["EmployeeName"].ToString();
			}
			string cmdText5 = fun.select("ModName", "tblModule_Master", "ModId='" + ModId + "'");
			SqlCommand sqlCommand5 = new SqlCommand(cmdText5, con);
			SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
			while (sqlDataReader5.Read())
			{
				lblModuleName.Text = sqlDataReader5["ModName"].ToString();
			}
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	public void BindData()
	{
		try
		{
			string cmdText = fun.select("SubModId,SubModName,MTR", "tblSubModule_Master", "ModId='" + ModId + "'Order By MTR Asc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("SubModId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("SubModName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MTR", typeof(string)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["SubModId"].ToString();
				dataRow[1] = sqlDataReader["SubModName"].ToString();
				switch (Convert.ToInt32(sqlDataReader["MTR"]))
				{
				case 1:
					dataRow[2] = "Master";
					break;
				case 2:
					dataRow[2] = "Transaction";
					break;
				case 3:
					dataRow[2] = "Report";
					break;
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

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("AccessModule.aspx?A=1&CompId=" + CompId + "&FYId=" + FinYearId);
	}

	protected void BtnSave_Click(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			foreach (GridViewRow row in GridView2.Rows)
			{
				string currDate = fun.getCurrDate();
				string currTime = fun.getCurrTime();
				string text = ((Label)row.FindControl("lblId")).Text;
				for (int i = 1; i <= 4; i++)
				{
					int num = 0;
					switch (i)
					{
					case 1:
						if (((CheckBox)row.FindControl("Cknew")).Checked)
						{
							num = 1;
						}
						break;
					case 2:
						if (((CheckBox)row.FindControl("CkEdit")).Checked)
						{
							num = 2;
						}
						break;
					case 3:
						if (((CheckBox)row.FindControl("CkDelete")).Checked)
						{
							num = 3;
						}
						break;
					case 4:
						if (((CheckBox)row.FindControl("CkPrint")).Checked)
						{
							num = 4;
						}
						break;
					}
					string text2 = "";
					string text3 = "";
					string cmdText = fun.select("*", "tblAccess_Master", "CompId='" + CompId + "'AND FinYearId='" + FinYearId + "' AND EmpId='" + EmpId + "' AND ModId='" + ModId + "' AND SubModId='" + text + "' AND AccessType='" + i + "'");
					SqlCommand selectCommand = new SqlCommand(cmdText, con);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables[0].Rows.Count == 0)
					{
						if (num > 0)
						{
							text2 = fun.insert("tblAccess_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,EmpId,ModId,SubModId,AccessType,Access", "'" + currDate + "','" + currTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + EmpId + "','" + ModId + "','" + text + "','" + i + "','" + num + "'");
							SqlCommand sqlCommand = new SqlCommand(text2, con);
							sqlCommand.ExecuteNonQuery();
						}
					}
					else
					{
						text3 = fun.update("tblAccess_Master", "SysDate='" + currDate + "',SysTime='" + currTime + "',SessionId='" + sId + "',Access='" + num + "'", " CompId='" + CompId + "'  And  FinYearId='" + FinYearId + "' And  EmpId='" + EmpId + "' And  ModId='" + ModId + "' And   SubModId='" + text + "'And AccessType='" + i + "'");
						SqlCommand sqlCommand2 = new SqlCommand(text3, con);
						sqlCommand2.ExecuteNonQuery();
					}
				}
			}
			string empty = string.Empty;
			empty = "User access is assigned.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
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

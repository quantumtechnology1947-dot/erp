using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_ProjectManagement_Transactions_ManPowerPlanning_Edit_Details : Page, IRequiresSessionState
{
	protected Label LName;

	protected TextBox TWONo;

	protected RequiredFieldValidator RequiredFieldTWONo;

	protected Label LDesignation;

	protected DropDownList DrpDepartment;

	protected Label Ldate;

	protected Label Label3;

	protected TextBox TAHrs;

	protected RequiredFieldValidator RequiredFieldValTAHrs;

	protected RegularExpressionValidator RegularTAHrs;

	protected DropDownList Drptype;

	protected Label Label2;

	protected TextBox TDescription;

	protected Label Label4;

	protected TextBox TActualDesc;

	protected Button BtnUpdate;

	protected Button BtnCancel;

	protected SqlDataSource SqlDept;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string SId = "";

	private int CompId;

	private int FinYearId;

	private Cal_Used_Hours CUH = new Cal_Used_Hours();

	private string Id = "0";

	private string CDate = "";

	private string CTime = "";

	private int GradeId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			SId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			Id = base.Request.QueryString["Id"].ToString();
			GradeId = Convert.ToInt32(base.Request.QueryString["GId"]);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (base.IsPostBack)
			{
				return;
			}
			con.Open();
			string cmdText = fun.select("EmpId,Date,WONo,Dept,Types,Description,Hours,ActualDesc", "tblPM_ManPowerPlanning", "Id='" + Id + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				string cmdText2 = fun.select("EmployeeName,Designation", "tblHR_OfficeStaff", "  tblHR_OfficeStaff.EmpId='" + sqlDataReader["EmpId"].ToString() + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					LName.Text = dataSet.Tables[0].Rows[0]["EmployeeName"].ToString();
					string cmdText3 = fun.select("tblHR_Designation.Symbol+ '-' + tblHR_Designation.Type AS Designation", "tblHR_Designation", " tblHR_Designation.Id='" + dataSet.Tables[0].Rows[0]["Designation"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					LDesignation.Text = dataSet2.Tables[0].Rows[0]["Designation"].ToString();
					Ldate.Text = fun.FromDateDMY(sqlDataReader["Date"].ToString());
					string text = "";
					if (sqlDataReader["WONo"] != DBNull.Value && sqlDataReader["WONo"].ToString() != "")
					{
						text = sqlDataReader["WONo"].ToString();
						TWONo.Enabled = true;
						DrpDepartment.Enabled = false;
					}
					else
					{
						text = "NA";
						TWONo.Enabled = false;
						DrpDepartment.Enabled = true;
					}
					TWONo.Text = text;
					string cmdText4 = fun.select("Symbol", "BusinessGroup", string.Concat("Id='", sqlDataReader["Dept"], "'"));
					SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						DrpDepartment.SelectedValue = sqlDataReader["Dept"].ToString();
					}
					Drptype.SelectedValue = sqlDataReader["Types"].ToString();
					TDescription.Text = sqlDataReader["Description"].ToString();
					TActualDesc.Text = sqlDataReader["ActualDesc"].ToString();
					TAHrs.Text = sqlDataReader["Hours"].ToString();
				}
			}
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/ProjectManagement/Transactions/ManPowerPlanning_Edit.aspx?ModId=7&SubModId=117");
	}

	protected void BtnUpdate_Click(object sender, EventArgs e)
	{
		try
		{
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			string text = "";
			int num = 0;
			int num2 = 0;
			double num3 = 0.0;
			if (TWONo.Text != "NA")
			{
				if (fun.CheckValidWONo(TWONo.Text, CompId, FinYearId))
				{
					text = TWONo.Text;
					num3 = CUH.BalanceHours_WONO(GradeId, text, CompId, FinYearId, 2);
				}
				else
				{
					num2++;
					string empty = string.Empty;
					empty = "WONo is invalid.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			else
			{
				num = Convert.ToInt32(DrpDepartment.SelectedValue);
				num3 = CUH.BalanceHours(GradeId, num, CompId, FinYearId, 2);
			}
			double num4 = 0.0;
			num4 = Convert.ToDouble(TAHrs.Text);
			if (num4 > 0.0)
			{
				if (num3 >= num4)
				{
					con.Open();
					if (num2 == 0 && !string.IsNullOrEmpty(TAHrs.Text) && fun.NumberValidation(TAHrs.Text))
					{
						string selectedValue = Drptype.SelectedValue;
						string text2 = TDescription.Text;
						string text3 = TActualDesc.Text;
						string cmdText = fun.select("SysDate,SysTime,SessionId,CompId,FinYearId,EmpId,Date,WONo,Dept,Types,Description,Hours,AmendmentNo,ActualDesc", "tblPM_ManPowerPlanning", "Id='" + Id + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText, con);
						SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
						while (sqlDataReader.Read())
						{
							if (sqlDataReader.HasRows)
							{
								string cmdText2 = fun.insert("tblPM_ManPowerPlanning_Amd", "MId,SysDate,SysTime,FinYearId,SessionId , CompId, EmpId , Date , WONo, Dept, Types, Description,Hours,AmendmentNo,ActualDesc", "'" + Convert.ToInt32(Id) + "','" + sqlDataReader["SysDate"].ToString() + "','" + sqlDataReader["SysTime"].ToString() + "','" + sqlDataReader["FinYearId"].ToString() + "','" + sqlDataReader["SessionId"].ToString() + "','" + sqlDataReader["CompId"].ToString() + "','" + sqlDataReader["EmpId"].ToString() + "','" + sqlDataReader["Date"].ToString() + "','" + sqlDataReader["WONo"].ToString() + "','" + sqlDataReader["Dept"].ToString() + "','" + Convert.ToInt32(sqlDataReader["Types"]) + "','" + sqlDataReader["Description"].ToString() + "'," + Convert.ToDouble(sqlDataReader["Hours"].ToString()) + ",'" + Convert.ToInt32(sqlDataReader["AmendmentNo"]) + "','" + sqlDataReader["ActualDesc"].ToString() + "'");
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
								sqlCommand2.ExecuteNonQuery();
								int num5 = 0;
								num5 = ((Convert.ToInt32(sqlDataReader["AmendmentNo"]) <= 0) ? 1 : (Convert.ToInt32(sqlDataReader["AmendmentNo"].ToString()) + 1));
								string cmdText3 = fun.update("tblPM_ManPowerPlanning", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + SId + "',WONo='" + text + "',Dept='" + num + "',Types='" + selectedValue + "',Description='" + text2 + "',Hours='" + num4 + "',AmendmentNo='" + num5 + "',ActualDesc='" + text3 + "'", " Id='" + Id + "'");
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
								sqlCommand3.ExecuteNonQuery();
								base.Response.Redirect("~/Module/ProjectManagement/Transactions/ManPowerPlanning_Edit.aspx?ModId=7&SubModId=117");
							}
						}
						con.Close();
					}
					else
					{
						string empty2 = string.Empty;
						empty2 = "Invalid input.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty3 = string.Empty;
					empty3 = "Only " + Math.Round(num3, 2) + " hours are remained.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty4 = string.Empty;
				empty4 = "Hours must greater than Zero.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}
}

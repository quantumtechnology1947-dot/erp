using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using MKB.TimePicker;

public class Module_ProjectManagement_Transactions_OnSiteAttendance_New : Page, IRequiresSessionState
{
	protected Label Label3;

	protected TextBox textChequeDate;

	protected CalendarExtender textDelDate_CalendarExtender;

	protected RequiredFieldValidator ReqDelDate;

	protected RegularExpressionValidator RegDelverylDate;

	protected DropDownList drpGroupF;

	protected Button btnProceed;

	protected Panel Panel1;

	protected GridView GridView4;

	protected Panel Panel5;

	protected Button btnAdd;

	protected SqlDataSource SqlDataBG;

	private string connStr = "";

	private SqlConnection con;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string CDate = "";

	private string CTime = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			Label3.Text = textChequeDate.Text;
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			textChequeDate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				FillGrid(0);
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid(int value)
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetBGEmp", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@BG", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@OnSiteDate", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@BG"].Value = value;
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters["@OnSiteDate"].Value = fun.FromDate(textChequeDate.Text).ToString();
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView4.DataSource = dataSet;
			GridView4.DataBind();
			GetValidate();
		}
		catch (Exception)
		{
		}
	}

	public void GetValidate()
	{
		try
		{
			foreach (GridViewRow row in GridView4.Rows)
			{
				if (((CheckBox)row.FindControl("ck")).Checked)
				{
					((RequiredFieldValidator)row.FindControl("ReqtxtOnsite")).Visible = true;
				}
				else
				{
					((RequiredFieldValidator)row.FindControl("ReqtxtOnsite")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void btnProceed_Click(object sender, EventArgs e)
	{
		FillGrid(Convert.ToInt32(drpGroupF.SelectedValue));
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			DateTime dateTime = Convert.ToDateTime($"{DateTime.Now:MM-dd-yyyy}");
			DateTime dateTime2 = Convert.ToDateTime($"{fun.FromDateMDY(textChequeDate.Text):MM-dd-yyyy}");
			if (dateTime2 >= dateTime)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				foreach (GridViewRow row in GridView4.Rows)
				{
					if (((CheckBox)row.FindControl("ck")).Checked)
					{
						num2++;
						if (((CheckBox)row.FindControl("ck")).Checked && ((TextBox)row.FindControl("txtOnsite")).Text != "" && textChequeDate.Text != "" && fun.DateValidation(textChequeDate.Text))
						{
							num++;
						}
					}
				}
				if (num2 == num && num > 0)
				{
					foreach (GridViewRow row2 in GridView4.Rows)
					{
						if (((CheckBox)row2.FindControl("ck")).Checked && ((TextBox)row2.FindControl("txtOnsite")).Text != "")
						{
							string code = fun.getCode(((Label)row2.FindControl("lblEmp")).Text);
							fun.chkEmpCustSupplierCode(code, 1, CompId);
							int num4 = Convert.ToInt32(((RadioButtonList)row2.FindControl("RadioButtonShift")).SelectedValue);
							int num5 = Convert.ToInt32(((RadioButtonList)row2.FindControl("RadioButtonStatus")).SelectedValue);
							string text = ((TextBox)row2.FindControl("txtOnsite")).Text;
							string text2 = ((TimeSelector)row2.FindControl("FTime")).Hour.ToString("D2") + ":" + ((TimeSelector)row2.FindControl("FTime")).Minute.ToString("D2") + ":" + ((TimeSelector)row2.FindControl("FTime")).Second.ToString("D2") + " " + ((TimeSelector)row2.FindControl("FTime")).AmPm;
							string text3 = fun.FromDate(textChequeDate.Text);
							string cmdText = "Select * from tblOnSiteAttendance_Master where CompId='" + CompId + "' And OnSiteDate='" + text3 + "' And EmpId='" + code + "'";
							SqlCommand selectCommand = new SqlCommand(cmdText, con);
							SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
							DataSet dataSet = new DataSet();
							sqlDataAdapter.Fill(dataSet);
							if (dataSet.Tables[0].Rows.Count == 0)
							{
								SqlCommand sqlCommand = new SqlCommand(fun.insert("tblOnSiteAttendance_Master", "CompId,SessionId,SysDate,SysTime,OnSiteDate,EmpId,Shift,Status,Onsite,FromTime,FinYearId", "'" + CompId + "','" + sId + "','" + CDate + "','" + CTime + "','" + text3 + "','" + code + "','" + num4 + "','" + num5 + "','" + text + "','" + text2 + "','" + FinYearId + "'"), con);
								con.Open();
								sqlCommand.ExecuteNonQuery();
								con.Close();
								num3++;
							}
						}
					}
				}
				else
				{
					string empty = string.Empty;
					empty = "Invalid input data.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
				if (num3 > 0)
				{
					FillGrid(Convert.ToInt32(drpGroupF.SelectedValue));
					return;
				}
				FillGrid(Convert.ToInt32(drpGroupF.SelectedValue));
				GetValidate();
			}
			else
			{
				string empty2 = string.Empty;
				empty2 = "Invalid date!";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}
}

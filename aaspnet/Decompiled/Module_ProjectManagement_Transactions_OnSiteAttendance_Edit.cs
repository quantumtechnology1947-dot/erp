using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using MKB.TimePicker;

public class Module_ProjectManagement_Transactions_OnSiteAttendance_Edit : Page, IRequiresSessionState
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
			DateTime value2 = Convert.ToDateTime($"{DateTime.Now:MM-dd-yyyy}");
			DateTime dateTime = Convert.ToDateTime($"{fun.FromDateMDY(textChequeDate.Text):MM-dd-yyyy}");
			TimeSpan timeSpan = dateTime.Subtract(value2);
			int num = 0;
			if (timeSpan.Days == -1 || timeSpan.Days >= 0)
			{
				num = 1;
			}
			else if (timeSpan.Days == -2 && dateTime.AddDays(1.0).DayOfWeek.ToString() == "Sunday")
			{
				num = 1;
			}
			if (num == 1)
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetOnSiteEmp", con);
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
			}
			else
			{
				string empty = string.Empty;
				empty = "Invalid date!";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnProceed_Click(object sender, EventArgs e)
	{
		FillGrid(Convert.ToInt32(drpGroupF.SelectedValue));
	}

	protected void GridView4_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView4.EditIndex = e.NewEditIndex;
			FillGrid(Convert.ToInt32(drpGroupF.SelectedValue));
			int editIndex = GridView4.EditIndex;
			GridViewRow gridViewRow = GridView4.Rows[editIndex];
			Convert.ToInt32(((Label)gridViewRow.FindControl("lblIdE")).Text);
			string text = ((Label)gridViewRow.FindControl("lblShiftE")).Text;
			string text2 = ((Label)gridViewRow.FindControl("lblStatusE")).Text;
			if (text == "Day")
			{
				((RadioButtonList)gridViewRow.FindControl("RadioButtonShift")).SelectedValue = "0";
			}
			else
			{
				((RadioButtonList)gridViewRow.FindControl("RadioButtonShift")).SelectedValue = "1";
			}
			if (text2 == "Present")
			{
				((RadioButtonList)gridViewRow.FindControl("RadioButtonStatus")).SelectedValue = "0";
			}
			else
			{
				((RadioButtonList)gridViewRow.FindControl("RadioButtonStatus")).SelectedValue = "1";
			}
			fun.TimeSelectorDatabase(((Label)gridViewRow.FindControl("lblFrmTimeE")).Text, (TimeSelector)gridViewRow.FindControl("FTime"));
			if (((Label)gridViewRow.FindControl("lblToTimeE")).Text != string.Empty)
			{
				fun.TimeSelectorDatabase(((Label)gridViewRow.FindControl("lblToTimeE")).Text, (TimeSelector)gridViewRow.FindControl("TTime"));
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView4_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView4.EditIndex = -1;
			FillGrid(Convert.ToInt32(drpGroupF.SelectedValue));
		}
		catch (Exception)
		{
		}
	}

	protected void GridView4_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView4.EditIndex;
			GridViewRow gridViewRow = GridView4.Rows[editIndex];
			int num = Convert.ToInt32(GridView4.DataKeys[e.RowIndex].Value);
			if (((TextBox)gridViewRow.FindControl("txtOnsite")).Text != "")
			{
				int num2 = Convert.ToInt32(((RadioButtonList)gridViewRow.FindControl("RadioButtonShift")).SelectedValue);
				int num3 = Convert.ToInt32(((RadioButtonList)gridViewRow.FindControl("RadioButtonStatus")).SelectedValue);
				string text = ((TextBox)gridViewRow.FindControl("txtOnsite")).Text;
				string text2 = ((TimeSelector)gridViewRow.FindControl("FTime")).Hour.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("FTime")).Minute.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("FTime")).Second.ToString("D2") + " " + ((TimeSelector)gridViewRow.FindControl("FTime")).AmPm;
				string text3 = ((TimeSelector)gridViewRow.FindControl("TTime")).Hour.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TTime")).Minute.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TTime")).Second.ToString("D2") + " " + ((TimeSelector)gridViewRow.FindControl("TTime")).AmPm;
				if (Convert.ToDateTime(text2).TimeOfDay < Convert.ToDateTime(text3).TimeOfDay)
				{
					string cmdText = fun.update("tblOnSiteAttendance_Master", "Shift='" + num2 + "', Status='" + num3 + "',UpSysDate='" + CDate + "',UpSessionId='" + sId + "',UpSysTime='" + CTime + "',Onsite='" + text + "',FromTime='" + text2 + "',ToTime='" + text3 + "'", "Id='" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					GridView4.EditIndex = -1;
					FillGrid(Convert.ToInt32(drpGroupF.SelectedValue));
				}
				else
				{
					string empty = string.Empty;
					empty = "From Time Should Be Less than To Time.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
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

	protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView4.PageIndex = e.NewPageIndex;
		FillGrid(Convert.ToInt32(drpGroupF.SelectedValue));
	}
}
